using MediatR;

namespace MSUAgent.Application.Queries.Chats;

public sealed record ChatQuery : IRequest<string>
{
    public string Message { get; set; } = null!;
}