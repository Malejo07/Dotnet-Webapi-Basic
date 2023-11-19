using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations
{
    public static class AuthConfigurations
    {
        public static IServiceCollection SetMyVaccineAuthConfigurations(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;

                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); Esto es para cerrar la sesion despues de 15 minutos
                //options.Lockout.MaxFailedAccessAttempts = 5; Esto es para bloquear el acceso despues de 5 intentos.
            }
            ).AddEntityFrameworkStores<MyVaccineAppDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,
                    //ValidIssuer = "tu_issuer",
                    //ValidAudience = "tu_audience",
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tu_clave_secreta")),
                    //ClockSkew = TimeSpan.Zero // Evita un desfase de tiempo (opcional)
                };
            });
            return services;
        }
    }
}
