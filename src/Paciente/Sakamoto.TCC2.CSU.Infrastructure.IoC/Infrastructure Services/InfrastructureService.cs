using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.Bus;
using Sakamoto.TCC2.CSU.Patients.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Context;
using Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Repository;
using Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.UnitOfWork;

namespace Sakamoto.TCC2.CSU.Infrastructure.IoC.Infrastructure_Services
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<PatientContext>();
        }
    }
}