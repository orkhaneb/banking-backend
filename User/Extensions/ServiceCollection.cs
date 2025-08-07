using Microsoft.EntityFrameworkCore;
using User.Data;
using User.Helper;
using User.Repositories;
using User.Services;

namespace User.Extensions
{
    public static class ServiceCollection
    {

        
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
