using ERandevuServer.Application.Services;
using ERandevuServer.Domain.Entities;
using ERandevuServer.Domain.Repositories;
using ERandevuServer.Infrastructure.Context;
using ERandevuServer.Infrastructure.Repositories;
using ERandevuServer.Infrastructure.Services;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
        }
    }
