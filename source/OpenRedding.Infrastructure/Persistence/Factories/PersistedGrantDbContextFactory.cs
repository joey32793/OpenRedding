﻿namespace OpenRedding.Infrastructure.Persistence.Factories
{
    using System;
    using System.Reflection;
    using IdentityServer4.EntityFramework.DbContexts;
    using IdentityServer4.EntityFramework.Options;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class PersistedGrantDbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        private const string ConnectionStringName = "ConnectionString";

        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            // Generic argument on .AddUserSecrets() need to reference a type within this assembly
            var configuration = new ConfigurationBuilder()
               .AddUserSecrets<PersistedGrantDbContextFactory>()
               .AddEnvironmentVariables()
               .Build();

            var connectionString = configuration[ConnectionStringName];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"Connection string {ConnectionStringName} is null or empty", connectionString?.GetType().Name);
            }

            var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
            var operationalOptions = new OperationalStoreOptions();

            optionsBuilder.UseSqlServer(connectionString, options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                options.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                options.CommandTimeout(30);
            });

            return new PersistedGrantDbContext(optionsBuilder.Options, operationalOptions);
        }
    }
}