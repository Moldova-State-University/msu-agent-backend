using MediatR;
using MSUAgent.TelegramBff.Commands;
using MSUAgent.TelegramBff.Queries.Chat;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MSUAgent.TelegramBff.Handlers;

public sealed class BotUpdateHandler
{
    private readonly IMediator _mediator;
    private readonly ITelegramCommandRegistry _commandRegistry;

    public BotUpdateHandler(IMediator mediator, ITelegramCommandRegistry commandRegistry)
    {
        _mediator = mediator;
        _commandRegistry = commandRegistry;
    }

    public async Task HandleAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message?.Text is not { } messageText)
        {
            return;
        }

        var request = messageText.StartsWith('/')
            ? _commandRegistry.FindCommand(messageText)
            : new ChatQuery(messageText);

        if (request is null)
        {
            return;
        }

        var result = await _mediator.Send(request, cancellationToken);

        await botClient.SendMessage(
            chatId: update.Message.Chat.Id,
            text: result,
            cancellationToken: cancellationToken);
    }
}