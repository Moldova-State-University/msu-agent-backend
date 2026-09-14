using MSUAgent.MobileBff.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceDiscovery();

builder.Services.AddHttpClient(
    "Backend",
    client =>
    {
        client.BaseAddress =
            new Uri("https+http://msuagent-api");
    })
    .AddServiceDiscovery();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpointGroups(typeof(Program).Assembly);

app.Run();