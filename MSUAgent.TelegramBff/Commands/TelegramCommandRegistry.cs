using MediatR;
using MSUAgent.TelegramBff.Queries.Chat;
using MSUAgent.TelegramBff.Queries.Health;

namespace MSUAgent.TelegramBff.Commands;

public sealed class TelegramCommandRegistry : ITelegramCommandRegistry
{
    private readonly Dictionary<string, Func<IRequest<string>>> _commands =
        new()
        {
            ["/health"] = () => new HealthQuery()//,
            //["/chat"] = () => new ChatQuery(),
        };

    public IRequest<string>? FindCommand(string command)
    {
        var a = _commands.TryGetValue(command, out var commandFactory2);

        return _commands.TryGetValue(command, out var commandFactory)
            ? commandFactory() 
            : null;
    }
}