﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.Bus;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.Bus.Configurations;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.Bus.Handler;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Context;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Repositories;
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
            services.AddScoped<IMessageEventHandler, MessageEventHandler>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IMessageConfigurations>(sp =>
                sp.GetRequiredService<IOptions<MessageConfigurations>>().Value);
            services.AddScoped<IPractitionerRepository, PractitionerRepository>();
            services.AddScoped<PractitionerContext>();
        }
    }
}