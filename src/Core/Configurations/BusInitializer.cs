﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Seedwork.CQRS.Bus.Core.Configurations
{
    public static class BusInitializer
    {
        public static IServiceCollection AddBusCore(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<BusInitializerOptionsBuilder> configure)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (configure == null) throw new ArgumentNullException(nameof(configure));
            
            var builder = new BusInitializerOptionsBuilder(configuration);

            configure(builder);

            var options = builder.Build();

            services
                .AddSingleton(BusConnectionString.Create(options.ConnectionString))
                .AddSingleton(typeof(IBusSerializer), options.SerializerImplementationType)
                .AddSingleton<BusConnection>();

            services
                .Configure<BusConnectionOptions>(instance => instance.Bind(options.ConnectionOptions));

            return services;
        }
    }
}