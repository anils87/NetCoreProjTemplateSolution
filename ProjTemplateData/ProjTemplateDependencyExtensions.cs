using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjTemplateCommon.Enums;
using ProjTemplateCommon.Extensions;
using ProjTemplateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjTemplateCommon.ConfigClasses;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ProjTemplateData
{
    public static class ProjTemplateDependencyExtensions
    {
        public static IServiceCollection UseProjTemplateData(this IServiceCollection services, IConfiguration configuration)
        {            
            services.UseDatabaseContexts(configuration);

            services.RegisterFromAssemblies(InjectionLifetime.Scoped, Assembly.GetExecutingAssembly());
            return services;
        }

        private static IServiceCollection UseDatabaseContexts(this IServiceCollection services, IConfiguration configuration)
        {
            ConnectionSetting connectionSetting = new ConnectionSetting() { SqlConnectionString= configuration.GetConnectionString("ProjTemplateDB") };
            services.AddSingleton(connectionSetting);
            
            services.AddDbContext<ProjTemplateDboContext>((svcProvider, opts) =>
            {
                opts.UseSqlServer(connectionSetting.SqlConnectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.EnableRetryOnFailure(5,TimeSpan.FromSeconds(30),null);
                })
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
                
            },contextLifetime: ServiceLifetime.Scoped ,optionsLifetime: ServiceLifetime.Singleton);

            services.AddScoped<ProjTemplateDboContext>();

            return services;
        }
    }
}
