// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingAudit.Infrastructure.Adapters.Logs;
using ParkingAudit.Infrastructure.DataContext;
using ParkingAudit.Infrastructure.Extensions;
using ParkingAudit.Worker;
using System.Reflection;




var configuration = new ConfigurationBuilder()
        .SetBasePath(Environment.CurrentDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddRabbitMqService();
        services.AddHostedService<Worker>();
        services.AddDbContextFactory<IntegracionDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ParkingDatabase")),
                    ServiceLifetime.Transient);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("ParkingAudit.Application")));
        services.AddTransient(typeof(AddLogsRepository));
    })
    .Build();

await host.RunAsync();
