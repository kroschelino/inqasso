using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Inqasso.Core;
using Inqasso.Core.Interfaces;
using Inqasso.Import;
using Inqasso.Import.Interfaces;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Serilog;

namespace Inqasso.Import
{



    [Command(
        Name = "Inqasso.Import"
        , Description = "My app is very cool 😎")]
    [HelpOption(
        "-h"
        , LongName = "help"
        , Description = "Get info")]
    [VersionOptionFromMember(
        "-v"
        , MemberName = nameof(GetVersion))]
    class Program
    {
        [Option(
            "-o"
            , "Some option"
            , CommandOptionType.SingleValue
            , LongName = "option")]
        [Range(1, 5)]
        public int Option { get; } = 1;



        public static Task<int> Main(string[] args) =>
            CommandLineApplication.ExecuteAsync<Program>(args);

        public async Task<int> OnExecuteAsync(CancellationToken cancellationToken)
        {
            var host = CreateHostBuilder();
            await host.RunConsoleAsync(cancellationToken);
            return Environment.ExitCode;
        }

        public class Worker : IHostedService
        {
            private readonly IImportService _myService;
            private readonly ILogger<Worker> _logger;
            private readonly IHostApplicationLifetime _hostLifetime;
            private int? _exitCode;

            public Worker(IImportService service, IHostApplicationLifetime hostLifetime, ILogger<Worker>? logger = null)
            {
                _logger = logger ?? NullLogger<Worker>.Instance;
                _myService = service ?? throw new ArgumentNullException(nameof(service));
                _hostLifetime = hostLifetime ?? throw new ArgumentNullException(nameof(hostLifetime));
            }

            public Task StartAsync(CancellationToken cancellationToken)
            {
                try
                {
                    _myService.DisplayProducts();
                    _exitCode = 0;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred");
                    _exitCode = 1;
                }
                finally
                {
                    _hostLifetime.StopApplication();
                }

                return Task.CompletedTask;
            }

            public Task StopAsync(CancellationToken cancellationToken)
            {
                Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
                _logger.LogInformation($"Shutting down the service with code {Environment.ExitCode}");
                return Task.CompletedTask;
            }
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureLogging(logging => { logging.ClearProviders(); })
                .UseSerilog((hostContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration);
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<Core.Core>();
                    services.AddTransient<IImportService, ImportApplication>();
                    services.AddHostedService<Worker>();
                });
        }

        private static string GetVersion()
            => typeof(Program).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                   ?.InformationalVersion ??
               string.Empty;


    }

}
