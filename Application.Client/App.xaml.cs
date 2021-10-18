using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Application.Client.Cache.Infrastructure.Repository.Extensions.DependencyInjection;
using Application.Client.Cache.Infrastructure.Services.Extensions.DependencyInjection;
using Application.Client.Dialogs.ColorDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.FindDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.FontDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.GoToLineDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.MessageDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Dialogs.OpenFileDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.ReplaceDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.SaveFileDialog.Extensions.DependencyInjection;
using Application.Client.Infrastructure.Environment.Enums;
using Application.Client.Infrastructure.ErrorHandling.Constants;
using Application.Client.Infrastructure.ErrorHandling.DataBinding.TraceListeners;
using Application.Client.Infrastructure.ErrorHandling.Models;
using Application.Client.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Services.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Main;
using Application.Utilities.Extensions;
using Application.Utilities.FileReader.Extensions.DependencyInjection;
using Application.Utilities.FileWriter.Extensions.DependencyInjection;
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
                        Environment.GetEnvironmentVariable(EnvironmentVariableKey.AspNetCoreEnvironment.GetEnumMemberAttrValue())!);

                    builder.AddInMemoryCollection(new[] { environment })
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

            ConfigureDataBindingErrorListener();

            Current.DispatcherUnhandledException += AppDispatcherUnhandledException;

            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();

            if (mainWindow == null)
            {
                throw new ArgumentNullException(nameof(mainWindow), "The value cannot be null!");
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
            services.AddMainWindow();

            services.AddMemoryCache();
            services.AddCacheServices();
            services.AddCacheRepositories();

            services.AddMessageDialog();
            services.AddSaveFileDialog();
            services.AddOpenFileDialog();
            services.AddFontDialog();
            services.AddFindDialog();
            services.AddColorDialog();
            services.AddReplaceDialog();
            services.AddGoToLineDialog();

            services.AddServices();

            services.AddTextFileReader();
            services.AddTextFileWriter();
        }

        private static void ConfigureDataBindingErrorListener()
        {
            PresentationTraceSources.Refresh();
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
            PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            IHostEnvironment hostEnvironment = _host.Services.GetRequiredService<IHostEnvironment>();
            ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();

            logger.LogError(e.Exception, e.Exception.Message);

            ErrorModel errorModel = new()
            {
                Message = e.Exception.Message,
                Exception = hostEnvironment.IsDevelopment() ? e.Exception.ToString() : ErrorConstants.NON_DEVELOPMENT_EXCEPTION_MESSAGE
            };

            ShowUnhandledException(errorModel);

            e.Handled = true;
        }

        private async void ShowUnhandledException(ErrorModel errorModel)
        {
            IMessageDialog messageDialog = _host.Services.GetRequiredService<IMessageDialog>();

            await messageDialog.ShowDialogAsync(new MessageDialogOptions
            {
                Content = $"An application error occurred.\n\n{errorModel.Message}.\n\n{errorModel.Exception}",
                Title = "Application Error",
                Button = MessageBoxButton.OK,
                Icon = MessageBoxImage.Error
            });

            Current.Shutdown();
        }
    }
}
