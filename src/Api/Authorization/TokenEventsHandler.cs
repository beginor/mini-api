using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Beginor.AppFx.Core;
using Beginor.AspNetCore.Authentication.Token;
using Beginor.MiniApi.Common;

namespace Beginor.MiniApi.Authorization;

public class TokenEventsHandler {

    public Task OnTokenReceived(TokenReceivedContext context) {
        var token = context.Token;
        if (token == "1234567890") {
            // 模拟一个用户
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(AppClaimTypes.Privilege, "cities.read"),
                new Claim(AppClaimTypes.Privilege, "cities.read_by_id"),
                new Claim(AppClaimTypes.Privilege, "cities.create"),
                new Claim(AppClaimTypes.Privilege, "cities.update"),
                new Claim(AppClaimTypes.Privilege, "cities.delete")
            };
            context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, TokenOptions.DefaultSchemaName));
            context.Success();
        }
        else {
            context.Fail("invalid token");
        }
        return Task.CompletedTask;
    }

}
