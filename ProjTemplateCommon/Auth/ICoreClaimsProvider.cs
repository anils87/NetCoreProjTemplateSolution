using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Auth
{
    public interface ICoreClaimsProvider
    {
        Task<CoreClaimsPrincipal> CreateCoreClaimPrincipalAsync(HttpContext httpContext,string email,string accessToken);
    }
}
