using System.Reflection;
using Application;
using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        if (Configuration.GetValue<string>("DatabaseEngine") == "MySql")
        {
            services.AddDbContext<RateMyWineContext>(
                options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27))));
        }
        else if (Configuration.GetValue<string>("DatabaseEngine") == "Sqlite")
        {
            services.AddDbContext<RateMyWineContext>(
                options => options.UseSqlite(connectionString));
        }

        services.AddValidatorsFromAssembly(typeof(IRateMyWineContext).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped<IRateMyWineContext, RateMyWineContext>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(IRateMyWineContext).Assembly);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(typeof(IRateMyWineContext));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}