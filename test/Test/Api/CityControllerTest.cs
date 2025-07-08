using NUnit.Framework;
using Beginor.MiniApi.Controllers;

namespace Beginor.MiniApi.Test.Api;

[TestFixture]
public class CityControllerTest : BaseTest<CityController> {

    [Test]
    public void _01_CanResolveTarget() {
        Assert.That(Target, Is.Not.Null);
    }

}
