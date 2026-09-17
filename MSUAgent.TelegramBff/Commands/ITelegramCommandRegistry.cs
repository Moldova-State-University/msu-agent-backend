using MediatR;

namespace MSUAgent.TelegramBff.Commands;

public interface ITelegramCommandRegistry
{
    IRequest<string>? FindCommand(string command);
}