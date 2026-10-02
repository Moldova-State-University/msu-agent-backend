using MediatR;
using MSUAgent.Application.Models.Results;

namespace MSUAgent.Application.Queries.Chats;

public sealed record ChatQuery(string Message) : IRequest<IResult<string>>;