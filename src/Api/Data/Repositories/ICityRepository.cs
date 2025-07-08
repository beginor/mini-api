using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Beginor.AppFx.Core;
using Beginor.MiniApi.Models;

namespace Beginor.MiniApi.Data.Repositories;

/// <summary>Table, cities 仓储接口</summary>
public partial interface ICityRepository : IRepository<CityModel, long> {

    /// <summary>搜索 Table, cities ，返回分页结果。</summary>
    Task<PaginatedResponseModel<CityModel>> SearchAsync(CitySearchModel model, CancellationToken token = default);

}
