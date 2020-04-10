using Covid19.Contracts;
using Covid19.Entities;
using Covid19.Logger;
using Covid19.Repositories;
using Covid19.Web.Context;
using Covid19.Web.Factories;
using Covid19.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Covid19.Web.Extensions
{
    public static class ServiceExtension
    {
        /*
         * covid19_connection_string
         * covid19
         */
        private const string CONNECTION_STRING_NAME = "covid19_connection_string";

        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING_NAME),
                    assembly => assembly.MigrationsAssembly(typeof(RepositoryContext).Assembly.FullName)));

            /*
             * Uncomment it for first time web deployment so that it can run the migrations files
             */
            //services.BuildServiceProvider().GetService<RepositoryContext>().Database.Migrate();

        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureIdentityUser(this IServiceCollection services, IConfiguration configuration)
        {
            // Add identity db context. identity dbcontext must be integrated with frontend application
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING_NAME),
                assembly => assembly.MigrationsAssembly(typeof(UserContext).Assembly.FullName)));
            services.AddIdentity<WebUser,IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = true;

                })
                .AddEntityFrameworkStores<UserContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/";
                options.AccessDeniedPath = "/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddScoped<IUserClaimsPrincipalFactory<WebUser>, UserClaimsFactory>();

            /*
             * Uncomment it for first time web deployment so that it can run the migrations files
             */
            //services.BuildServiceProvider().GetService<UserContext>().Database.Migrate();

        }
    }
}
