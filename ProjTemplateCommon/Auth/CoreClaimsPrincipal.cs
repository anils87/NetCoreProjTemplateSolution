using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Auth
{
    public class CoreClaimsPrincipal : ClaimsPrincipal
    {
        public CoreClaimsPrincipal(ClaimsPrincipal claimsPrincipal,string email,string token): base(claimsPrincipal)
        {
            Email = email;
            AccessToken = token;
        }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IPAddress ClientIP { get; set; }
        public List<string> Roles { get; set; }
    }
}
