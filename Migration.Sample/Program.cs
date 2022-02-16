using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Migration.Sample.Extensions;
using Migration.Sample.Infrastructure;
using Serilog.Core;
using System;

namespace Migration.Sample
{
    public static class Migrate
    {
        static Logger logger = AppSettings.GetLogger();

        public static void Main(string[] args)
        {
            logger.Information($"Starting the migration process at {DateTime.Now}");

            logger.Information($"Retriving connection string");

            string conn = Environment.GetEnvironmentVariable("CONN_STRING");

            logger.Information($"Preparing to apply changes");

            IServiceProvider service = DatabaseExtension.GetMigrateService(conn);

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = service.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            logger.Information($"Applied");
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            IMigrationRunner runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            if (!runner.HasMigrationsToApplyUp())
            {
                logger.Information($"The database is in the latest version of the migration and there are no changes to make");

                return;
            }

            // List all changes to apply 
            runner.ListMigrations();

            // Begin migration transaction
            runner.Processor.BeginTransaction();

            try
            {
                // Run migration 
                runner.MigrateUp();

                runner.Processor.CommitTransaction();
            }
            catch (Exception ex)
            {
                runner.Processor.RollbackTransaction();

                logger.Error($"An error was occured: {ex.InnerException.Message}");

                throw;
            }
        }
    }
}
