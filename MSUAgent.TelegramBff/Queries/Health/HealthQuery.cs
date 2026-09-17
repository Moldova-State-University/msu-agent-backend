using MediatR;

namespace MSUAgent.TelegramBff.Queries.Health;

public sealed record HealthQuery : IRequest<string>;