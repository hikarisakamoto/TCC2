using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.Bus;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Context;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Repositories;

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
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddScoped<IMedicalRecordContext, MedicalRecordContext>();
        }
    }
}