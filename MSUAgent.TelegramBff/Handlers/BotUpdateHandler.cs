using MSUAgent.TelegramBff.Clients;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MSUAgent.TelegramBff.Handlers;

public sealed class BotUpdateHandler
{
    private readonly IMSUAgentClient _msuAgentClient;

    public BotUpdateHandler(IMSUAgentClient msuAgentClient)
    {
        _msuAgentClient = msuAgentClient;
    }
    public async Task HandleAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message?.Text is not { } messageText) 
        {
            return;
        }
        
        if (messageText == "/health")
        {
            var response = await _msuAgentClient.SendHealthRequest(cancellationToken);

            await botClient.SendMessage(
                chatId: update.Message.Chat.Id,
                text: $"Health: {(int)response.StatusCode}",
                cancellationToken: cancellationToken);
        }
    }
}
