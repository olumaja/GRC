using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Transport;

namespace GrcApi
{
    public static class Extensions
    {
        public static void RegisterSerilog(this WebApplicationBuilder builder)
        {
            // builder.Services.AddOptions<LoggerSettings>().BindConfiguration(nameof(LoggerSettings));

            _ = builder.Host.UseSerilog((_, sp, serilogConfig) =>
            {
                // var loggerSettings = sp.GetRequiredService<IOptions<LoggerSettings>>().Value;
                string appName = "GRC_API";
                string elasticSearchUrl = "";
                bool writeToFile = true;
                bool structuredConsoleLogging = true;
                string minLogLevel = "loggerSettings.MinimumLogLevel";
                //ConfigureEnrichers(serilogConfig, appName);
                //ConfigureConsoleLogging(serilogConfig, structuredConsoleLogging);
                ConfigureWriteToFile(serilogConfig, writeToFile);
                // ConfigureElasticSearch(builder, serilogConfig, appName, elasticSearchUrl);
                // ConfigureGraylog(builder, serilogConfig, loggerSettings.GrayLogUrl, loggerSettings.GrayLogPort);
                ConfigureGraylog(builder, serilogConfig, "192.168.230.105", 12201);
                SetMinimumLogLevel(serilogConfig, minLogLevel);
                OverideMinimumLogLevel(serilogConfig);

            });
        }

        private static void ConfigureEnrichers(LoggerConfiguration serilogConfig, string appName)
        {
            serilogConfig
                            .Enrich.FromLogContext()
                            .Enrich.WithProperty("Application", appName)
                            // .Enrich.WithExceptionDetails()
                            .Enrich.WithMachineName()
                            .Enrich.WithProcessId()
                            .Enrich.WithThreadId()
                            .Enrich.FromLogContext();
        }

        private static void ConfigureConsoleLogging(LoggerConfiguration serilogConfig, bool structuredConsoleLogging)
        {
            if (structuredConsoleLogging)
            {
                serilogConfig.WriteTo.Async(wt => wt.Console(new CompactJsonFormatter()));
            }
            else
            {
                serilogConfig.WriteTo.Async(wt => wt.Console());
            }
        }

        private static void ConfigureWriteToFile(LoggerConfiguration serilogConfig, bool writeToFile)
        {
            if (writeToFile)
            {
                serilogConfig.WriteTo.File(
                 new CompactJsonFormatter(),
                 "Logs/logs.json",
                 restrictedToMinimumLevel: LogEventLevel.Information,
                 rollingInterval: RollingInterval.Day,
                 retainedFileCountLimit: 5);
            }
        }

        private static void ConfigureElasticSearch(WebApplicationBuilder builder, LoggerConfiguration serilogConfig, string appName, string elasticSearchUrl)
        {
            if (!string.IsNullOrEmpty(elasticSearchUrl))
            {
                string? formattedAppName = appName?.ToLower().Replace(".", "-").Replace(" ", "-");
                string indexFormat = $"{formattedAppName}-logs-{builder.Environment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.Now:yyyy-MM}";
                // serilogConfig.WriteTo.Async(writeTo =>
                //writeTo.Elasticsearch(new(new Uri(elasticSearchUrl))
                //{
                //    AutoRegisterTemplate = true,
                //    IndexFormat = indexFormat,
                //    MinimumLogEventLevel = LogEventLevel.Information,
                //})).Enrich.WithProperty("Environment", builder.Environment.EnvironmentName!);
            }
        }

        private static void OverideMinimumLogLevel(LoggerConfiguration serilogConfig)
        {
            serilogConfig
                         .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                         .MinimumLevel.Override("Hangfire", LogEventLevel.Warning)
                         .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                         .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error);
        }
        private static void ConfigureGraylog(WebApplicationBuilder builder, LoggerConfiguration serilogConfig, string graylogUrl, int port)
        {
            if (!string.IsNullOrEmpty(graylogUrl))
            {
                serilogConfig.WriteTo.Async(writeTo =>
                writeTo.Graylog(new GraylogSinkOptions
                {
                    HostnameOrAddress = graylogUrl,
                    Port = port,
                    MinimumLogEventLevel = LogEventLevel.Information,
                    Facility = builder.Environment.ApplicationName,
                    TransportType = TransportType.Udp
                }));
            }
        }
        private static void SetMinimumLogLevel(LoggerConfiguration serilogConfig, string minLogLevel)
        {
            switch (minLogLevel.ToLower())
            {
                case "debug":
                    serilogConfig.MinimumLevel.Debug();
                    break;
                case "information":
                    serilogConfig.MinimumLevel.Information();
                    break;
                case "warning":
                    serilogConfig.MinimumLevel.Warning();
                    break;
                default:
                    serilogConfig.MinimumLevel.Information();
                    break;
            }
        }
    }
}
