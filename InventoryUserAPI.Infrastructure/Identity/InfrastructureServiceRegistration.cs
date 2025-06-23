using Microsoft.Extensions.DependencyInjection;
using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Infrastructure.Repositories;

namespace InventoryUserAPI.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
