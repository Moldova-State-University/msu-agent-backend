using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSUAgent.MigrationService;
using MSUAgent.Infrastructure.Persistence;
using MSUAgent.Infrastructure.Migrations;

var builder = Host.CreateApplicationBuilder(args);
    var services = builder.Services;

services.AddHostedService<DbMigrator>();

services.AddScoped<IDataSeeder, DataSeeder>();

services.AddDbContextPool<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MSUAgentDb"),
        sqlOptions =>
        {
            sqlOptions.MigrationsAssembly(typeof(InitialUserManagement).Assembly.FullName);
            sqlOptions.ExecutionStrategy(c => new NonRetryingExecutionStrategy(c));
        }));

var app = builder.Build();
app.Run();