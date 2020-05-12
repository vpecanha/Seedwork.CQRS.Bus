﻿using System;

namespace Seedwork.CQRS.Bus.Core.Configurations
{
    public class BusInitializerOptions
    {
        public BusInitializerOptions(string connectionString, BusConnectionOptions connectionOptions, Type serializerImplementationType)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            ConnectionOptions = connectionOptions ?? throw new ArgumentNullException(nameof(connectionOptions));
            SerializerImplementationType = serializerImplementationType ??
                                           throw new ArgumentNullException(nameof(serializerImplementationType));
        }

        public BusConnectionOptions ConnectionOptions { get; protected set; }
        public  string ConnectionString { get; protected set; }
        public  Type SerializerImplementationType { get; protected set; }
    }
}