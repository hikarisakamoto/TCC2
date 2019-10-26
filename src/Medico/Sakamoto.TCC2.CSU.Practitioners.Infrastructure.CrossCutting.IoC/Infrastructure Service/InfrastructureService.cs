using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.Bus;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Context;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Repository;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.UnitOfWork;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.IoC.Infrastructure_Service
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
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPractitionerRepository, PractitionerRepository>();
            services.AddTransient<PractitionerContext>();
        }
    }
}