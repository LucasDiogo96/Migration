using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Migration.Sample.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceProvider GetMigrateService(string connection)
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSqlServer2012()
                    // Set the connection string
                    .WithGlobalConnectionString(connection)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(Migrate).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }
    }
}
