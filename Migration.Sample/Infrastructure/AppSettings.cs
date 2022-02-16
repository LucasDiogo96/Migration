using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Migration.Sample.Infrastructure
{
    public static class AppSettings
    {
        public static Logger GetLogger()
        {
            LoggerConfiguration settings = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .WriteTo.Debug();

            return settings.CreateLogger();
        }
    }
}
