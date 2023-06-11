using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ManningApi.Repositories;
using ManningApi.Repositories.Interfaces;
using ManningApi.Services;
using ManningApi.Services.Interfaces;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ManningAPI
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

            builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true);

            string FrontendUrl = builder.Configuration["Frontend:FrontendUrl"]!;

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "FrontendUrl", policy =>
                {
                    policy.WithOrigins(FrontendUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            // Add services to the container.
            string connString = builder.Configuration.GetConnectionString("UserConnectionString") ?? "";
            builder.Services.AddDbContext<ManningDbContext>(options => options.UseSqlServer(connString));

            builder.Services.AddScoped<IZonesRepository, ZonesRepository>();
            builder.Services.AddScoped<IOpStationRepository, OpStationRepository>();
            builder.Services.AddScoped<ITrainingRequirementRepository, TrainingRequirementRepository>();
            builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
            builder.Services.AddScoped<IOperatorCompletedTrainingRepository, OperatorCompletedTrainingRepository>();
            builder.Services.AddScoped<IClockInRepository, ClockInRepository>();

            builder.Services.AddScoped<ILineService, LineService>();
            builder.Services.AddScoped<ITrainingRequirementService, TrainingRequirementService>();
            builder.Services.AddScoped<IOpStationService, OpStationService>();
            builder.Services.AddScoped<ILoginService, LoginService>();


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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(config => {
                config.SwaggerDoc("0.1", new OpenApiInfo {
                    Title = "Manning Board API",
                    Version = "0.1"
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description = @"JWT Bearer authentication. Enter 'bearer' followed by your token to authenticate.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}