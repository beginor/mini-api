using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beginor.AppFx.Api;
using Beginor.AppFx.Core;
using Beginor.MiniApi.Models;
using Beginor.MiniApi.Data.Repositories;
using Beginor.MiniApi.Common;

namespace Beginor.MiniApi.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController() : Controller {

    [HttpGet("")]
    public AccountModel GetAccountInfo() {
        var account = new AccountModel();
        var user = this.User;
        if (user.Identity!.IsAuthenticated) {
            account.Id = user.GetUserId()!;
            account.UserName = user.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            account.GivenName = user.Claims.First(c => c.Type == ClaimTypes.GivenName).Value;
            account.Surname = user.Claims.First(c => c.Type == ClaimTypes.Surname).Value;
            account.Roles = user.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .ToDictionary(c => c.Value, c => true);
            account.Privileges = user.Claims
                .Where(c => c.Type == AppClaimTypes.Privilege)
                .ToDictionary(c => c.Value, c => true);
            account.Token = "1234567890";
        }
        return account;
    }
}
