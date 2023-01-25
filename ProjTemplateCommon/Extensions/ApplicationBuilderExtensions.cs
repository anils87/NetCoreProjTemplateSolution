using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Hosting;
using ProjTemplateCommon.Middleware;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        //public static IApplicationBuilder UseCommonApp(this IApplicationBuilder builder, IWebHostEnvironment env,IApiVersionDescriptionProvider provider)
        public static IApplicationBuilder UseCommonApp(this IApplicationBuilder builder, IWebHostEnvironment env)
        {
            builder.UseCustomExceptionHandling();
            builder.UseCommonAppendTransactionId();
            builder.UseCommonAppendJwtToken();
            builder.UseCommonRequestResponseMiddleware();
            //builder.UseCommonSwagger(env,provider);
            builder.UseCommonSwagger(env);
            builder.UseCommonMiniProfiler(env);
            return builder;
        }
        //public static IApplicationBuilder UseCommonSwagger(this IApplicationBuilder builder, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        public static IApplicationBuilder UseCommonSwagger(this IApplicationBuilder builder, IWebHostEnvironment env)
        {
            if (!env.IsProduction() && !(env.EnvironmentName.ToUpper() == "PROD"))
            {
                builder.UseSwagger();
                builder.UseSwaggerUI();
                //builder.UseSwaggerUI(delegate (SwaggerUIOptions options)
                //{
                //    //string text = (string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..");
                //    options.SwaggerEndpoint("/swagger/swagger.json","Project Template API");

                //    // Below Code to add for api versioning
                //    //foreach(ApiVersionDescription apiVersionDescription in provider.ApiVersionDescriptions)
                //    //{
                //    //    options.SwaggerEndpoint(text + "/swagger/" + apiVersionDescription.GroupName + "/swagger.json", apiVersionDescription.GroupName.ToUpperInvariant());
                //    //}
                //    options.DisplayRequestDuration();
                //});
            }
            return builder;
        }
        public static IApplicationBuilder UseCommonMiniProfiler(this IApplicationBuilder builder,IWebHostEnvironment env)
        {
            if(!env.IsProduction() && !(env.EnvironmentName.ToUpper() == "PROD"))
            {
                builder.UseMiniProfiler();
            }
            return builder;
        }        
        public static IApplicationBuilder UseCommonRequestResponseMiddleware(this IApplicationBuilder builder)
        {
            builder.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = (ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto),
                ForwardLimit = 10
            });
            return builder;
        }
    }
}
