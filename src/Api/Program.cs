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
        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    
    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
        services.AddDbContext<RateMyWineContext>(
            options => options.UseMySql("name=ConnectionStrings:DefaultConnection", serverVersion));

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
