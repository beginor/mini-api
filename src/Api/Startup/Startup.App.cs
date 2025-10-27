using Beginor.AppFx.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Beginor.MiniApi.Startup;

partial class Startup {

    private void ConfigureAppServices(IServiceCollection services, IWebHostEnvironment env) {
        services.AddDistributedMemoryCache();
        services.AddServices(
            typeof(Startup).Assembly,
            t => t.Name.EndsWith("Repository"),
            ServiceLifetime.Scoped
        );
    }

    private static void ConfigureApp(WebApplication app, IWebHostEnvironment env) {
        // do nothing now.
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

}
