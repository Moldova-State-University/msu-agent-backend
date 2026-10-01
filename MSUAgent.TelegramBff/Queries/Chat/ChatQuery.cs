using MediatR;

namespace MSUAgent.TelegramBff.Queries.Chat;

public sealed record ChatQuery(string Message) : IRequest<string>;