using Microsoft.EntityFrameworkCore;
using User.Data;
using User.Helper;
using User.Repositories;
using User.Services;

namespace User.Extensions
{
    public static class ServiceCollection
    {

        //: IServiceCollection .Net Coreda DI üçün istifadə olunan interfeysdir.Servislər avtomatik olaraq constructor-a inject olunur (DI)
        public static IServiceCollection AddUserServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<JwtTokenGenerator>();

            return services;
        }
    }
}
