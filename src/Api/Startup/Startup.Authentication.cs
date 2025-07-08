using Beginor.AspNetCore.Authentication.Token;
using Beginor.MiniApi.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Beginor.MiniApi.Startup;

partial class Startup {

    private void ConfigureAuthenticationServices(IServiceCollection services, IWebHostEnvironment env) {
        services.AddAuthentication(auth => {
            auth.DefaultAuthenticateScheme = TokenOptions.DefaultSchemaName;
            auth.DefaultChallengeScheme = TokenOptions.DefaultSchemaName;
        }).AddToken(token => {
            var handler = new TokenEventsHandler();
            token.Events = new TokenEvents {
                OnTokenReceived = handler.OnTokenReceived
            };
        });
        // authorization;
        services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
    }

    private void ConfigureAuthentication(WebApplication app, IWebHostEnvironment env) {
        app.UseAuthentication();
        app.UseAuthorization();
    }

}
