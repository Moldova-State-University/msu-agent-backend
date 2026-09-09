var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MSUAgent_Api>("msuagent-api");

builder.Build().Run();
