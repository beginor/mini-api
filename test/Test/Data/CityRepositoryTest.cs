using System;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.NetCore;
using NUnit.Framework;
using Beginor.MiniApi.Data.Entities;
using Beginor.MiniApi.Data.Repositories;
using Beginor.MiniApi.Models;

namespace Beginor.MiniApi.Test.Data;

/// <summary>Table, cities仓储测试</summary>
[TestFixture]
public class CityRepositoryTest : BaseTest<ICityRepository> {

    [Test]
    public void _01_CanResolveTarget() {
        Assert.That(Target, Is.Not.Null);
    }

    [Test]
    public async Task _02_CanDoSearchAsync() {
        var searchModel = new CitySearchModel {
            Skip = 0,
            Take = 10
        };
        var result = await Target.SearchAsync(searchModel);
        Assert.That(result.Total, Is.GreaterThanOrEqualTo(0));
        Assert.That(result.Take, Is.GreaterThanOrEqualTo(result.Data!.Count));
    }

}
