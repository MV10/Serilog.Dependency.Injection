using Serilog.Core;

namespace Serilog.Injection
{
    public interface ILoggerWithIP<T> : ILogEventEnricher
    {
        ILogger Logger { get; }
    }
}
