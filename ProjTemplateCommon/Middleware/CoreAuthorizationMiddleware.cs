using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ProjTemplateCommon.Auth;
using ProjTemplateCommon.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Middleware
{
    public class CoreAuthorizationMiddleware
    {
        const string KeyPrefix = "Author_";
        private readonly RequestDelegate _next;
        private readonly ICacheService _cacheService;
        private readonly ICoreClaimsProvider _claimsProvider;
        private readonly IConfiguration _configuration;
        private int _cacheTimeoutInSeconds = 300; // 5 min
        public CoreAuthorizationMiddleware(RequestDelegate next,ICacheService cacheService, ICoreClaimsProvider coreClaimsProvider,IConfiguration configuration)
        {
            _next = next;
            _cacheService = cacheService;
            _claimsProvider = coreClaimsProvider;
            _configuration = configuration;
            if(_configuration["CoreClaimsPrincipalCacheInSeconds"] != null )
                _cacheTimeoutInSeconds =Convert.ToInt32(_configuration["CoreClaimsPrincipalCacheInSeconds"]);
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if(await ValidateTokenAsync(httpContext))
                await _next(httpContext);
            else
                await HandleInvalidRequest(httpContext);

        }
        private async Task<bool> ValidateTokenAsync(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)            
                return false;
            
            var user = httpContext.User;

            var email = user.Claims.FirstOrDefault(m => m.Type == ClaimTypes.Email);
            if (email == null)
                return false;

            //Validate Token here
            Func<Task<CoreClaimsPrincipal>> func = async () =>
            {
                CoreClaimsPrincipal coreClaimsPrincipal = await _claimsProvider.CreateCoreClaimPrincipalAsync(httpContext, email.Value, token);
                if (coreClaimsPrincipal == null)
                    return null;
                return coreClaimsPrincipal;
            };


            // GET Or SET Cache for core claim principal data
            string key = $"{KeyPrefix}_{email}";
            var principal = await _cacheService.GetCacheDataAsync(key, func, _cacheTimeoutInSeconds);

            httpContext.User = principal;

            return true;
        }
        private async Task HandleInvalidRequest(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await httpContext.Response.WriteAsync("Bad Request");
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CoreAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCommonCoreAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CoreAuthorizationMiddleware>();
        }
    }
}
