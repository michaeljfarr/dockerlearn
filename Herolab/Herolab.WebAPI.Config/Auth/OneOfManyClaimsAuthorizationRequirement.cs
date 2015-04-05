using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Security;

namespace Herolab.WebAPI
{
    public class OneOfManyClaimsAuthorizationRequirement : IAuthorizationRequirement
    {
        public Claim[] OneOfTheseClaims { get; set; }

        public OneOfManyClaimsAuthorizationRequirement(params Claim[] oneOfTheseClaims)
        {
            OneOfTheseClaims = oneOfTheseClaims;
        }
    }

    public class OneOfManyClaimsAuthorizationHandler : AuthorizationHandler<OneOfManyClaimsAuthorizationRequirement>
    {
        public override async Task<bool> CheckAsync(AuthorizationContext context, OneOfManyClaimsAuthorizationRequirement requirement)
        {
            //either master or pin based auth code.
            var user = context.User;
            if (requirement.OneOfTheseClaims.Any(claim => user.HasClaim(claim.Type, claim.Value)))
            {
                context.Succeed(requirement);
                return true;
            }
            return false;
        }
    }

    public class NoneOneOfTheseClaimsAuthorizationRequirement : IAuthorizationRequirement
    {
        public Claim[] OneOfTheseClaims { get; set; }

        public NoneOneOfTheseClaimsAuthorizationRequirement(params Claim[] oneOfTheseClaims)
        {
            OneOfTheseClaims = oneOfTheseClaims;
        }
    }

    public class NoneOneOfTheseClaimsAuthorizationHandler : AuthorizationHandler<NoneOneOfTheseClaimsAuthorizationRequirement>
    {
        public override async Task<bool> CheckAsync(AuthorizationContext context, NoneOneOfTheseClaimsAuthorizationRequirement requirement)
        {
            //either master or pin based auth code.
            var user = context.User;
            if (requirement.OneOfTheseClaims.Any(claim => user.HasClaim(claim.Type, claim.Value)))
            {
                context.Fail();
                return false;
            }
            return true;
        }
    }
}