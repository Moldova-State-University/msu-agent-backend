using MediatR;

namespace MSUAgent.Application.Queries.Chats;

public sealed record ChatQuery(string Message) : IRequest<string>;