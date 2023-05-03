using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjTemplateCommon.Auth;
using ProjTemplateCommon.Caching;
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
        public static IServiceCollection AddCommonMemoryCache(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton<MemoryCacheOptions>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            return services;
        }

        public static IServiceCollection AddCommonAuthorization(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["TokenIssuer"];
                    options.Audience = configuration["TokenClientID"];
                });
            return services;
        }

        public static IServiceCollection AddCommonCoreAPIAuthorization(this IServiceCollection services)
        {
            services.AddSingleton<ICoreClaimsProvider, CoreClaimsProvider>();
            return services;
        }

    }
}
