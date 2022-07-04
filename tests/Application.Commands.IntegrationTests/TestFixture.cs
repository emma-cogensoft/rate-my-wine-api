using Api;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Persistence;

namespace ApiTests;

public class TestFixture
{
    private static IServiceScopeFactory _scopeFactory = null!;

    public TestFixture()
    {
        Initialise();
    }

    private void Initialise()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();
        var startup = new Startup(configuration);

        var services = new ServiceCollection();
        services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
            w.EnvironmentName == "Development" &&
            w.ApplicationName == "Api"));

        services.AddLogging();

        startup.ConfigureServices(services);

        _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();

        CreateDatabase();
        SeedDatabase();
    }

    private void SeedDatabase()
    {
        const int numRecords = 40;
        
        for (var i = 1; i <= numRecords; i++)
        {
            Add(
                new Manufacturer
                {
                    Id = i,
                    Name = $"Test Manufacturer {i}"
                });

            Add(
                new Beverage
                {
                    Id = i,
                    Name = $"Test Beverage {i}",
                    ManufacturerId = i
                });
        }
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
    
    public TEntity? Find<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        return context.Find<TEntity>(keyValues);
    }

    public async Task AddAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        await context.AddAsync(entity);

        await context.SaveChangesAsync();
    }
    
    private void Add<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        context.Add(entity);

        context.SaveChanges();
    }

    public async Task<int> CountAsync<TEntity>() where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        return await context.Set<TEntity>().CountAsync();
    }

    private void CreateDatabase()
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<RateMyWineContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    
    [CollectionDefinition("Commands Test fixture collection")]
    public class DatabaseCollection : ICollectionFixture<TestFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}