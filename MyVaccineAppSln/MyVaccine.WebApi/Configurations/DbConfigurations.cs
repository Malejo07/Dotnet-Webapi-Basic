using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Models;
using System.Runtime.CompilerServices;

namespace MyVaccine.WebApi.Configurations
{
    public static class DbConfigurations
    {
        public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
        {
            //var connectionString = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
            var connectionString = "Server=localhost,1433;Database=MyVaccineAppDb;User Id=sa;Password=Malejo07_;TrustServerCertificate=True;";
            services.AddDbContext<MyVaccineAppDbContext>(options =>
                        options.UseSqlServer(
                            connectionString
                            )
                        );
            return services;
        }
    }
}
