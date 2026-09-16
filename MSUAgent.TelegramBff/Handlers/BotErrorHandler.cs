using Microsoft.Extensions.Logging;

namespace MSUAgent.TelegramBff.Handlers;

public sealed class BotErrorHandler
{
    private readonly ILogger<BotErrorHandler> _logger;

    public BotErrorHandler(ILogger<BotErrorHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An error occurred while processing Telegram bot update.");
        return Task.CompletedTask;
    }
}
