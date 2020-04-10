using Covid19.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Covid19.Web.Factories
{
    public class UserClaimsFactory : UserClaimsPrincipalFactory<WebUser>
    {
        public UserClaimsFactory(UserManager<WebUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(WebUser user)
        {

            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Firstname", user.FirstName));
            identity.AddClaim(new Claim("Lastname", user.LastName));
            return identity;
        }
    }
}
