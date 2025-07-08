using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NHibernate;
using NHibernate.Linq;
using Beginor.AppFx.Core;
using Beginor.AppFx.Repository.Hibernate;
using Beginor.MiniApi.Data.Entities;
using Beginor.MiniApi.Models;

namespace Beginor.MiniApi.Data.Repositories;

/// <summary>Table, cities仓储实现</summary>
public partial class CityRepository(
    ISession session, IMapper mapper
) : HibernateRepository<City, CityModel, long>(session, mapper),
    ICityRepository {

    /// <summary>搜索 Table, cities ，返回分页结果。</summary>
    public async Task<PaginatedResponseModel<CityModel>> SearchAsync(
        CitySearchModel model,
        CancellationToken token = default
    ) {
        var query = Session.Query<City>();
        // todo: 添加自定义查询；
        var total = await query.LongCountAsync(token);
        var data = await query.OrderByDescending(e => e.Id)
            .Skip(model.Skip).Take(model.Take)
            .ToListAsync(token);
        return new PaginatedResponseModel<CityModel> {
            Total = total,
            Data = Mapper.Map<IList<CityModel>>(data),
            Skip = model.Skip,
            Take = model.Take
        };
    }

}
