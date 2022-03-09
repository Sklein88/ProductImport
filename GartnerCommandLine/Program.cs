using Application.Client;
using Application.Interfaces;
using Application.Repositories;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using ProductImport;

#region DI

ServiceProvider _serviceProvider;

void DisposeServices()
{
    if (_serviceProvider == null)
    {
        return;
    }
    if (_serviceProvider is IDisposable)
    {
        ((IDisposable)_serviceProvider).Dispose();
    }
}

#endregion

void RegisterServices()
{
    var services = new ServiceCollection();
    services.AddSingleton<IProductService, ProductService>();
    services.AddSingleton<IProductRepositoryU, ProductRepository>();
    services.AddSingleton<IClientService, ClientService>();

    services.AddSingleton<ConsoleApplication>();


    _serviceProvider = services.BuildServiceProvider(true);
}

//Added DI and for that the DI region
//and the RegisterServices method in here, the app 
//starts in <ConsoleApplication>().Run() , after that everything is disposed.

RegisterServices();
IServiceScope scope = _serviceProvider.CreateScope();

//App start
scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
DisposeServices();

