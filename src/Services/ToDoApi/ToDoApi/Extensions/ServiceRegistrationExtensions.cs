using ToDoApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Database;

namespace ToDoApi.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddClassesToDependencyInjection(typeof(IService));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddClassesToDependencyInjection(typeof(IRepository));

            return services;
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddClassesToDependencyInjection(this IServiceCollection services, Type type)
        {
            var assembly = typeof(Program).Assembly;

            var types = assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false }
                            && t.GetInterfaces().Contains(type))
                .ToList();

            foreach (var implementationType in types)
            {
                var interfaceType = implementationType.GetInterfaces().First(i => i != type);

                services.AddScoped(interfaceType, implementationType);
            }

            return services;
        }
    }
}
