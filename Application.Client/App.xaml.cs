using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Application.Client.Core.Application.Providers;
using Application.Client.Windows.Main;
using Application.Core.Environment.StaticValues;
using Application.Core.Environment.StaticValues.Enums;
using Application.Core.ErrorHandling.Constants;
using Application.Core.ErrorHandling.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Application.Client
{
    public partial class App
    {
        private readonly IHost _host;

        public App()
        {
            _host = new HostBuilder()
                .ConfigureHostConfiguration(builder =>
                {
                    KeyValuePair<string, string> environment = new(HostDefaults.EnvironmentKey,
                        Environment.GetEnvironmentVariable(EnvironmentVariables.GetEnvironmentVariableKey(EnvironmentVariableKey.AspNetCoreEnvironment)));

                    builder.AddInMemoryCollection(new[] {environment})
                        .AddEnvironmentVariables();
                })
                .ConfigureAppConfiguration(builder =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices(ConfigureServices)
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                    logging.AddNLog(context.Configuration);
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            Current.DispatcherUnhandledException += AppDispatcherUnhandledException;

            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();

            if (mainWindow == null)
            {
                throw new ArgumentNullException(nameof(mainWindow), @"The value cannot be null!");
            }

            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingletonServices();
            services.AddScopedServices();
            services.AddTransientServices();
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            IHostEnvironment hostEnvironment = _host.Services.GetRequiredService<IHostEnvironment>();
            ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();

            logger.LogError(e.Exception, e.Exception.Message);

            ClientErrorModel errorModel = new()
            {
                Message = e.Exception.Message,
                Exception = hostEnvironment.IsDevelopment() ? e.Exception.ToString() : ClientErrorConstants.NON_DEVELOPMENT_EXCEPTION_MESSAGE
            };

            ShowUnhandledException(errorModel);

            e.Handled = true;
        }

        private static void ShowUnhandledException(ClientErrorModel errorModel)
        {
            string errorMessage = $"An application error occured.\n\n{errorModel.Message}.\n\n{errorModel.Exception}";

            if (MessageBox.Show(errorMessage, "Application Error", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
            {
                Current.Shutdown();
            }
        }
    }
}
