using Microsoft.AspNetCore.Http;
using ProjTemplateCommon.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateTests.Helpers
{
    public class TestCoreClaimsProvider : ICoreClaimsProvider
    {
        public async Task<CoreClaimsPrincipal> CreateCoreClaimPrincipalAsync(HttpContext httpContext, string email, string accessToken)
        {
            var testUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,"00u1xf0hqsr4MDFT078wh9"),
                new Claim(ClaimTypes.Name,"Test User"),
                new Claim(ClaimTypes.Email,"Test.User@test.com")
            }));

            CoreClaimsPrincipal coreClaimsPrincipal = new CoreClaimsPrincipal(testUser,email,accessToken);
            coreClaimsPrincipal.UserId = "00u1xf0hqsr4MDFT078wh9";
            coreClaimsPrincipal.UserName = "Test User";
            coreClaimsPrincipal.Email = "Test.User@test.com";            
            return coreClaimsPrincipal;
        }
    }
}
