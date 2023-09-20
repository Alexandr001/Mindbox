using System.Reflection;
using FluentMigrator.Runner;

namespace Api.Core.Extensions;

public static class MigrationExtension
{
	public static void ConfigureMigrations(this IServiceCollection service, string connectDb)
	{
		service.AddLogging(c => c.AddFluentMigratorConsole())
		       .AddFluentMigratorCore()
		       .ConfigureRunner(c => c.AddSqlServer()
		                              .WithGlobalConnectionString(connectDb)
		                              .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
	}

	public static IHost RunMigrate(this IHost host, Migrate migrate, long version = 0)
	{
		using IServiceScope scope = host.Services.CreateScope();
		IMigrationRunner migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
		try {
			switch (migrate) {
				case Migrate.UP:
					migrationService.MigrateUp(version);
					break;
				case Migrate.DOWN:
					migrationService.MigrateDown(version);
					break;
			}
			return host;

		} catch (Exception e) {
			Console.WriteLine(e);
			throw;
		}
	}
}

public enum Migrate
{
	UP,
	DOWN
}