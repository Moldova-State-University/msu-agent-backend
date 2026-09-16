using Microsoft.Extensions.Configuration;
using MSUAgent.Hosting.Aspire.Extentions;

var builder = DistributedApplication.CreateBuilder(args);

var telegramBotToken = builder.AddParameter(
    "telegram-bot-token",
    secret: true);

var useLocalDatabase = builder.Configuration.GetSection("UseLocalDatabase").Get<bool>()!;

if (useLocalDatabase)
{
    var persistDatabase = builder.Configuration.GetSection("Databases:Persist").Get<bool>()!;

    var msuAgentDbPassword = builder.Configuration.GetSection("Databases:MSUAgentDb:Password").Get<string>()!;
    var msuAgentDb = builder.AddMSUAgentDatabase(msuAgentDbPassword, persistDatabase);

    var migrationService = builder.AddMigrationService(msuAgentDb);

    var backend = builder.AddMSUAgentApi(msuAgentDb, migrationService);
    builder
        .AddProject<Projects.MSUAgent_MobileBff>("msu-agent-mobile-bff")
        .WithReference(backend)
        .WaitFor(backend);

    builder
        .AddProject<Projects.MSUAgent_TelegramBff>("msu-agent-telegram-bff")
        .WithReference(backend)
        .WithEnvironment("Telegram__BotToken", telegramBotToken)
        .WaitFor(backend);
}
else
{
    var backend = builder.AddProject<Projects.MSUAgent_Api>("msu-agent-api");
    builder
        .AddProject<Projects.MSUAgent_MobileBff>("msu-agent-mobile-bff")
        .WithReference(backend)
        .WaitFor(backend);
    builder
        .AddProject<Projects.MSUAgent_TelegramBff>("msu-agent-telegram-bff")
        .WithReference(backend)
        .WithEnvironment("Telegram__BotToken", telegramBotToken)
        .WaitFor(backend);
}

builder.Build().Run();