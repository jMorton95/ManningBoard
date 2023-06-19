using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Manning.Api.Repositories;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services;
using Manning.Api.Services.Interfaces;
using System.Text;
using SignalRChat.Hubs;
using Microsoft.EntityFrameworkCore;

namespace Manning.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddJsonFile($"appsettings.Development.json");
            }
            else if (builder.Environment.IsProduction())
            {
                builder.Configuration.AddJsonFile($"appsettings.Production.json");
            }

            //builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true);

            string CorsPolicy = "Frontend";
            string FrontendUrl = builder.Configuration["Frontend:FrontendUrl"]!;

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "Frontend", policy =>
                {
                    policy.WithOrigins(FrontendUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            // Add services to the container.
            string connString = builder.Configuration.GetConnectionString("PostgresConnection") ?? "";
            builder.Services.AddDbContext<ManningDbContext>(options => options.UseNpgsql(connString));

            builder.Services.AddScoped<IZonesRepository, ZonesRepository>();
            builder.Services.AddScoped<IStationRepository, StationRepository>();
            builder.Services.AddScoped<ITrainingRequirementRepository, TrainingRequirementRepository>();
            builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
            builder.Services.AddScoped<IOperatorCompletedTrainingRepository, OperatorCompletedTrainingRepository>();
            builder.Services.AddScoped<IClockInRepository, ClockInRepository>();
            builder.Services.AddScoped<IStationStateRepository, StationStateRepository>();

            builder.Services.AddScoped<ILineService, LineService>();
            builder.Services.AddScoped<ITrainingRequirementService, TrainingRequirementService>();
            builder.Services.AddScoped<IStationService, StationService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IOperatorService, OperatorService>();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            });

            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(CorsPolicy);
            app.UseAuthorization();
            app.MapControllers();
            app.MapHub<LineHub>("/lineHub");
            app.Run();
        }
    }
}