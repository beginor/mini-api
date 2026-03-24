using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Beginor.AppFx.Core;

namespace Beginor.MiniApi.Models;

public partial class AccountModel {
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string GivenName { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Dictionary<string, bool> Roles { get; set; } = [];
    public Dictionary<string, bool> Privileges { get; set; } = [];
    public string Token { get; set; } = string.Empty;
}
