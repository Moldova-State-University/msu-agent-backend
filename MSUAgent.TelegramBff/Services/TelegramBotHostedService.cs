using Microsoft.Extensions.Hosting;
using MSUAgent.TelegramBff.Handlers;
using Telegram.Bot;

namespace MSUAgent.TelegramBff.Services;

public sealed class TelegramBotHostedService : BackgroundService
{

    private readonly ITelegramBotClient _botClient;
    private readonly BotUpdateHandler _updateHandler;
    private readonly BotErrorHandler _errorHandler;

    public TelegramBotHostedService(
        ITelegramBotClient botClient,
        BotUpdateHandler updateHandler,
        BotErrorHandler errorHandler)
    {
        _botClient = botClient;
        _updateHandler = updateHandler;
        _errorHandler = errorHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _botClient.StartReceiving(
            updateHandler: _updateHandler.HandleAsync,

            errorHandler: async(botClient, exception, cancellationToken) =>
            {
                await _errorHandler.HandleAsync(exception, cancellationToken);
            },
            cancellationToken: stoppingToken);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}
