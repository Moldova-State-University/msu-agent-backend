using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(MSUAgent.Application.AssemblyReference).Assembly));

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/status", async (IMediator mediator) =>
{
    var status = await mediator.Send(new MSUAgent.Application.Queries.GetStatusQuery());
    return Results.Ok(status);
});

app.MapHealthChecks("/health");

app.Run();