using System.Diagnostics;
using KoalaKit.Primitives.Results;
using Microsoft.Extensions.Logging;

namespace Koalakit.Orchestrations.Behaviors;

public class LoggingBehavior<TOperation, TResponse>(ILoggerFactory loggerFactory) : IKoalaBehavior<TOperation, TResponse>
    where TOperation : notnull
    where TResponse : KoalaResult
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<LoggingBehavior<TOperation, TResponse>>();

    public async Task<TResponse> Handle(TOperation request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {RequestName} with parameters: {RequestParameters}", typeof(TOperation).Name, request);

        var stopwatch = Stopwatch.StartNew();
        var response = await next(cancellationToken);
        stopwatch.Stop();

        _logger.LogInformation("Handled {RequestName} -> {ResponseName} in {ElapsedMilliseconds}ms", typeof(TOperation).Name, typeof(TResponse).Name, stopwatch.ElapsedMilliseconds);
        return response;
    }
}