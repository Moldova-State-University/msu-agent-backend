using Microsoft.Extensions.Configuration;
using MSUAgent.Hosting.Aspire.Extentions;

var builder = DistributedApplication.CreateBuilder(args);

var useLocalDatabase = builder.Configuration.GetSection("UseLocalDatabase").Get<bool>()!;

if (useLocalDatabase)
{
    var persistDatabase = builder.Configuration.GetSection("Databases:Persist").Get<bool>()!;

    var msuAgentDbPassword = builder.Configuration.GetSection("Databases:MSUAgentDb:Password").Get<string>()!;
    var msuAgentDb = builder.AddMSUAgentDatabase(msuAgentDbPassword, persistDatabase);

    var migrationService = builder.AddMigrationService(msuAgentDb);

    builder.AddMSUAgentApi(msuAgentDb, migrationService);
}
else
{
    builder.AddProject<Projects.MSUAgent_Api>("msu-agent-api");
}

builder.Build().Run();