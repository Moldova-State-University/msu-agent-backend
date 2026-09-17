using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSUAgent.TelegramBff.Commands;
using MSUAgent.TelegramBff.Extensions;
using MSUAgent.TelegramBff.Handlers;
using MSUAgent.TelegramBff.Services;
using Telegram.Bot;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddSingleton<TelegramCommandRegistry>();

var botToken = builder.Configuration["Telegram:BotToken"]
    ?? throw new InvalidOperationException(
        "Telegram BotToken is not configured.");

builder.Services.AddSingleton<ITelegramBotClient>(
    new TelegramBotClient(botToken));

builder.Services.AddServiceDiscovery();
builder.Services.AddBackendHttpClient(builder.Configuration);

builder.Services.AddSingleton<BotErrorHandler>();
builder.Services.AddSingleton<BotUpdateHandler>();
builder.Services.AddHostedService<TelegramBotHostedService>();

var host = builder.Build();

host.Run();