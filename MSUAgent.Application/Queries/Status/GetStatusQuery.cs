using MediatR;

namespace MSUAgent.Application.Queries.Status;

public sealed record GetStatusQuery : IRequest<string>;