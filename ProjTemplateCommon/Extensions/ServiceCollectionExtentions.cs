using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjTemplateCommon.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddCommonMiniProfiler(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
            }).AddEntityFramework();
           
            return services;
        }
    }
}
