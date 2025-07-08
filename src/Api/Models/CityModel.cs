using System;
using System.ComponentModel.DataAnnotations;
using Beginor.AppFx.Core;
#nullable disable
namespace Beginor.MiniApi.Models;
/// <summary>Table, cities模型</summary>
public partial class CityModel : StringEntity {
    /// <summary>name, varchar</summary>
    public string Name { get; set; }
    /// <summary>population, int4</summary>
    public int? Population { get; set; }
}
/// <summary>Table, cities搜索参数</summary>
public partial class CitySearchModel : PaginatedRequestModel { }