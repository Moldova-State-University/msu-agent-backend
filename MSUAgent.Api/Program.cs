using MSUAgent.Api.Extensions;
using MSUAgent.Api.Middlewares;
using MSUAgent.Application.Queries;
using MSUAgent.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetStatusQuery).Assembly));

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseMiddlewares();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.MapEndpointGroups(typeof(Program).Assembly);

app.MapHealthChecks("/health");

app.Run();