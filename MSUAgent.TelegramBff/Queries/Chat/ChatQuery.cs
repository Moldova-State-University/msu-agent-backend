using MediatR;

namespace MSUAgent.TelegramBff.Queries.Chat;

public sealed record ChatQuery : IRequest<string>
{
    public string Message { get; set; } = null!;
}