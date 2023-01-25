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
            services.AddDbContext<ProjTemplateDboContext>((svcProvider, opts) =>
            {
                //var dbCommandInterceptor = svcProvider.GetService<ProjTemplateDboContext>();

                opts.UseSqlServer(configuration.GetConnectionString("ProjTemplateDB"))
               // .UseSnakeCaseNamingConvention() // Naming Convention
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
                //.AddInterceptores(dbCommandInterceptor);
            });
            return services;
        }
    }
}
