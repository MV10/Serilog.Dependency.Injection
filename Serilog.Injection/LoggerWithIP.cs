using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.Http;

namespace Serilog.Injection
{
    /// <summary>
    /// Injects a reference to a Serilog ILogger that registers context properties for Type and the IP from HttpContext.
    /// </summary>
    public class LoggerWithIP<T> : ILoggerWithIP<T>
    {
        private readonly ILogger logger;
        private readonly IHttpContextAccessor contextAccessor;
        public LoggerWithIP(ILogger logger, IHttpContextAccessor contextAccessor)
        {
            this.logger = logger.ForContext(typeof(T)).ForContext(this as ILogEventEnricher);
            this.contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Returns a Serilog ILogger registered with Type and IP properties.
        /// </summary>
        public ILogger Logger => logger;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            string ip = $"({contextAccessor.HttpContext?.Connection.RemoteIpAddress.ToString() ?? "unknown"})";
            logEvent.AddPropertyIfAbsent(new LogEventProperty("IP", new ScalarValue(ip)));
        }
    }
}
