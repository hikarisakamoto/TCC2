using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.Bus;

namespace Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.IoC.Infrastructure_Services
{
    internal class InfrastructureService
    {
        internal static void Register(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Infra - Data
        }
    }
}