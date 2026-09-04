using MediatR;

namespace MSUAgent.Application.Queries;

public sealed record GetStatusQuery : IRequest<string>;