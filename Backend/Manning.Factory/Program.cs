using Manning.Factory.SeedFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Manning.Api.Repositories;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

var serviceProvider = new ServiceCollection().AddDbContext<ManningDbContext>(options => {
  options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
})
.BuildServiceProvider();

using (var context = serviceProvider.GetService<ManningDbContext>()){
  DataSeeder dataSeeder = new(context!);
  dataSeeder.RunDataSeed();
}
