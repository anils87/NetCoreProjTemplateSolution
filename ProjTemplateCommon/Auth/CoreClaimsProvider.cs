using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Auth
{
    public class CoreClaimsProvider : ICoreClaimsProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        public CoreClaimsProvider(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }
        public async Task<CoreClaimsPrincipal> CreateCoreClaimPrincipalAsync(HttpContext httpContext, string email, string accessToken)
        {
            CoreClaimsPrincipal coreClaimsPrincipal = new CoreClaimsPrincipal(httpContext.User, email, accessToken);
            coreClaimsPrincipal.UserId = httpContext.User.Claims.FirstOrDefault()?.Value;
            coreClaimsPrincipal.ClientIP = httpContext.Connection.RemoteIpAddress;

            var groupClaims = httpContext.User.Claims.Where(m => m.Type == "groups");
            coreClaimsPrincipal.Roles = groupClaims.Select(m => m.Value).ToList();
            
            // to read value from config
            var configValue = _configuration["externalUrl"];

            // to read values from service
            SetPropertiesFromService(coreClaimsPrincipal);

            return await Task.FromResult(coreClaimsPrincipal);
        }
        private void SetPropertiesFromService(CoreClaimsPrincipal coreClaimsPrincipal)
        {
            var scope = this._serviceProvider.CreateScope();
            
            // Below is the syntax to create instance to service and get data
            //IUserService userService = scope.ServiceProvider.GetService<IUserService>();
        }
    }
}
