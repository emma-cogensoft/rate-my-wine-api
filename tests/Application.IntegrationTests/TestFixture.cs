using Api;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Persistence;

namespace ApiTests;

public class TestFixture : IDisposable
{
    private static IServiceScopeFactory _scopeFactory = null!;

    public TestFixture()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();
        
        var services = new ServiceCollection();
        
        services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
            w.EnvironmentName == "Development" &&
            w.ApplicationName == "Api"));

        services.AddLogging();

        var configuration = builder.Build();
        var startup = new Startup(configuration);
        startup.ConfigureServices(services);
        

        _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();

        EnsureDatabase();
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        return await mediator.Send(request);
    }

    public async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        return await context.FindAsync<TEntity>(keyValues);
    }

    public async Task AddAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        context.Add(entity);

        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync<TEntity>() where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        return await context.Set<TEntity>().CountAsync();
    }

    public void Dispose()
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        context.Database.EnsureDeleted();
    }
    
    private void EnsureDatabase()
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        var manufacturer = context.Manufacturers.Add(new Manufacturer { Name = "Test Manufacturer" });
        context.SaveChanges();
        context.Beverages.Add(new Beverage { ManufacturerId = manufacturer.Entity.Id, Name = "Test Beverage" });
        context.SaveChanges();
    }
    
    [CollectionDefinition("Test fixture collection")]
    public class DatabaseCollection : ICollectionFixture<TestFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
