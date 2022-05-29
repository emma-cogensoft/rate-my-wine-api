using Api.Controllers;
using Application;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Persistence;

namespace Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.AddJsonFile("appsettings.development.json", true);
        
        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<RateMyWineContext>();    
            context.Database.Migrate();
        }

        app.Run();
    }
    
    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<RateMyWineContext>(
            options => options.UseMySql(connectionString, serverVersion));

        services.AddScoped<IRateMyWineContext, RateMyWineContext>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"))
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddDownstreamWebApi("DownstreamApi", configuration.GetSection("DownstreamApi"))
            .AddInMemoryTokenCaches();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(IRateMyWineContext).Assembly);
        services.AddAutoMapper(typeof(BeveragesController).Assembly);
        services.AddMediatR(typeof(IRateMyWineContext));
    }
}
