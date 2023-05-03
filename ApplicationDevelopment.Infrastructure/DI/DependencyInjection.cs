using ApplicationDevelopment.Application.Common.Interfaces;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Infrastructure.Persistence;
using ApplicationDevelopment.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("AppDevPostGreSQL"),
                        b =>
                            b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),
                ServiceLifetime.Transient);

                services.AddIdentity<User, Role>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireAdminRole", policy =>
                        policy.RequireAuthenticatedUser()
                              .RequireRole("admin"));

                    options.AddPolicy("RequireStaffRole", policy =>
                        policy.RequireAuthenticatedUser()
                              .RequireRole("staff"));

                    options.AddPolicy("RequireAdminOrStaffRole", policy =>
                        policy.RequireAuthenticatedUser()
                              .RequireRole("admin", "staff"));

                    options.AddPolicy("RequireAdminOrStaffOrUserRole", policy =>
                        policy.RequireAuthenticatedUser()
                              .RequireRole("admin", "staff", "user"));


                    options.AddPolicy("RequireUserRole", policy =>
                        policy.RequireAuthenticatedUser()
                              .RequireRole("user"));
                });




                services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
                services.AddTransient<IDateTime, DateTimeService>();
                services.AddTransient<IAuthentication, AuthenticationService>();
                services.AddTransient<CloudinaryService>();
                return services;
            }
        }
    }
}
