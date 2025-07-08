using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Beginor.AspNetCore.Authentication.Token;
using Beginor.MiniApi.Common;

namespace Beginor.MiniApi.Authorization;

public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider {

    public AuthorizationPolicyProvider(
        IOptions<AuthorizationOptions> options
    ) : base(options) { }

    public override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName) {
        var builder = new AuthorizationPolicyBuilder();
        builder.RequireAuthenticatedUser()
            .RequireClaim(AppClaimTypes.Privilege, policyName)
            .AddAuthenticationSchemes(
                TokenOptions.DefaultSchemaName
            );
        return Task.FromResult<AuthorizationPolicy?>(builder.Build());
    }

}
