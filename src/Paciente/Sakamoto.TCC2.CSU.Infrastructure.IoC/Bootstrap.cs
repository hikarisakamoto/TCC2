using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Infrastructure.IoC.Domain_Services;
using Sakamoto.TCC2.CSU.Infrastructure.IoC.Infrastructure_Services;

namespace Sakamoto.TCC2.CSU.Infrastructure.IoC
{
    /// <summary>
    ///     Extension method for IServiceCollection to register application services in the DI container
    /// </summary>
    public static class Bootstrap
    {
        /// <summary>
        ///     Registers the Patient component service classes. Operation in the DI container
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        /// <returns></returns>
        public static IServiceCollection Register(this IServiceCollection services)
        {
            DomainService.Register(services);
            InfrastructureService.Register(services);
            return services;
        }
    }
}