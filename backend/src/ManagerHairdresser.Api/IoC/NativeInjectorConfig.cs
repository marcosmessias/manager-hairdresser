using FluentValidation;
using ManagerHairdresser.Application.Interfaces.Services;
using ManagerHairdresser.Data.Context;
using ManagerHairdresser.Domain.Entities;
using ManagerHairdresser.Domain.Entities.Validations;
using ManagerHairdresser.Identity.Data;
using ManagerHairdresser.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ManagerHairdresser.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            services.AddDbContext<IdentityDataContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();
        }

        public static void RegisterValidators(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValidator<Customer>, CustomerValidator>();
            services.AddTransient<IValidator<Item>, ItemValidator>();
            services.AddTransient<IValidator<Item>, ItemValidator>();
            services.AddTransient<IValidator<Order>, OrderValidator>();
            services.AddTransient<IValidator<OrderItem>, OrderItemValidator>();
        }
    }
}
