using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Repositories.Implementations;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection SetDependencyInjections (this IServiceCollection services)
        {
            #region Repositories Injection
            services.AddScoped<IUserRepository, UserRepository> ();
            services.AddScoped<IBaseRepository<Dependent>, BaseRepository<Dependent>>();//con esto nos olvidamos de crear ese repositorio del modelo Dependet, basta con el básico,no se hace como el repositorio de User ya que ese va a tener mas funcionalidades 
            services.AddScoped<IBaseRepository<Allergy>, BaseRepository<Allergy>>();
            #endregion

            #region Services Injection
            services.AddScoped<IUserService, UserService> ();
            services.AddScoped<IDependentService, DependentService> ();
            services.AddScoped<IAllergyService, AllergyService> ();
            #endregion

            return services;
        }
    }
}
