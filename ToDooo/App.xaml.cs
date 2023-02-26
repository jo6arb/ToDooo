using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDooo.Data;
using ToDooo.Services;
using ToDooo.ViewModels;

namespace ToDooo
{
	public partial class App
	{
		private static IHost __Host;

		public static IHost Host => __Host 
			??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

		public static IServiceProvider Services => __Host.Services;
		private static IHostBuilder CreateHostBuilder(string[] args) => Microsoft.Extensions.Hosting.Host
		   .CreateDefaultBuilder(args)
		   .ConfigureServices(ConfigureServices)
		;

		private static void ConfigureServices(HostBuilderContext host, IServiceCollection service) => service
				.AddDataBase()
				.AddViewModels()
				.AddServices()
		;
		protected override async void OnStartup(StartupEventArgs e)
		{
			var host = Host;

            using (var scope = Services.CreateScope())
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();

            base.OnStartup(e);
			await Host.StartAsync();
		}

		protected override async void OnExit(ExitEventArgs e)
		{
			var host = Host;
			base.OnExit(e);
			await Host.StopAsync();
		}
	}
}
