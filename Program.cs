using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Extensions.DurableTask;
using Microsoft.Azure.Functions.Worker;
using Microsoft.AspNetCore.SignalR;
using OrderProcessingFunctionApp.Hubs;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        // ? Register Durable Functions
        services.AddDurableTask();

        // ? Register SignalR Hub
        services.AddSignalR();
    })
    .Build();

host.Run();
