using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjTemplateCommon.ConfigClasses;
using ProjTemplateCommon.Enums;
using ProjTemplateCommon.Extensions;
using ProjTemplateCommon.Mapping;
using ProjTemplateData;
using ProjTemplateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService
{
    public static class ProjTemplateServiceDependencyExtensions
    {
        public static IServiceCollection UseProjTemplateServices(this IServiceCollection services
            ,IConfiguration configuration)
        {
            //services.AddLogging();

            // services.Configure<LogConfig>(configuration.GetSection("LogConfig"));
            services.UseProjTemplateData(configuration);

            services.RegisterFromAssemblies(InjectionLifetime.Scoped,Assembly.GetExecutingAssembly());
                       
            services.ConfigureMapping();
            services.AddCommonMiniProfiler();
           
            // Register below line to enable windows authentication
           // services.AddAuthenticationCore(NegotiateDefaults.AuthenticationSchema).AddNegotiate();

            return services;
        }
        public static IServiceCollection ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            }).CreateMapper();
            services.AddSingleton(x => mappingConfig);
            services.AddSingleton<IMappingEngine, AutoMapperEngine>();
            return services;
        }
        
    }
}
