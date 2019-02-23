using SocialApp.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace SocialApp.Core
{
	public class Program
	{
		public static IConfiguration Configuration { get; set; }
		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<GoingOutContext>();
					DbInitializer.Initialize(context);
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}
			host.Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(
				(WebHostBuilderContext context, IConfigurationBuilder builder) =>
				{
					builder
						.AddEnvironmentVariables()
						.AddJsonFile("config.json", optional: false, reloadOnChange: true);
				})

				.UseStartup<Startup>()
				.Build();
	}
}
