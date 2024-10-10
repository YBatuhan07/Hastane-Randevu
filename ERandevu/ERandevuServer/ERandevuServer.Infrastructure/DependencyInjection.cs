using ERandevuServer.Domain.Entities;
using ERandevuServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace ERandevuServer.Infrastructure;

public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        services.AddIdentity<AppUser, AppRole>(Action =>
        {
            Action.Password.RequiredLength = 1;
            Action.Password.RequireUppercase = false;
            Action.Password.RequireLowercase = false;
            Action.Password.RequireNonAlphanumeric = false;
            Action.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        services.Scan(action =>
        {
            action.FromAssemblies(typeof(DependencyInjection).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });
        return services;
        }
    }
