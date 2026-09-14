using YamlDotNet.Core.Tokens;

var builder = DistributedApplication.CreateBuilder(args);

var backend = builder.AddProject<Projects.MSUAgent_Api>("msuagent-api");
builder.AddProject<Projects.MSUAgent_MobileBff>("msuagent-mobile-bff").WithReference(backend);

builder.Build().Run();
