using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Repositories;
using ReactManningPoCAPI.Repositories.Interfaces;
using ReactManningPoCAPI.Services;
using ReactManningPoCAPI.Services.Interfaces;

namespace ReactManningPoCAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ENVIRONMENT_NAME");
            var AllowedLocalOrigins = "_AllowedLocalOrigins";

            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json", false, true);
            if (!string.IsNullOrEmpty(environmentName))
            {
                builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json");
            }
            builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedLocalOrigins, policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader();
                });
            });
           
            // Add services to the container.
            string connString = builder.Configuration?.GetConnectionString("userConnectionString");
            builder.Services.AddDbContext<ManningDbContext>(options => options.UseSqlServer(connString));

            builder.Services.AddScoped<IZonesRepository, ZonesRepository>();
            builder.Services.AddScoped<IOpStationRepository, OpStationRepository>();
            builder.Services.AddScoped<ITrainingRequirementRepository, TrainingRequirementRepository>();
            builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
            builder.Services.AddScoped<IOperatorCompletedTrainingRepository, OperatorCompletedTrainingRepository>();

            builder.Services.AddScoped<ILineService, LineService>();
            builder.Services.AddScoped<ITrainingRequirementService, TrainingRequirementService>();
            builder.Services.AddScoped<IOpStationService, OpStationService>();




            builder.Services.AddControllers();
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

            app.UseCors(AllowedLocalOrigins);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}