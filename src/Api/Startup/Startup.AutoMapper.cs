using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Beginor.MiniApi.Startup;

partial class Startup {

    private static void ConfigureAutoMapperServices(IServiceCollection services, IWebHostEnvironment env) {
        services.AddAutoMapper(
            configure => {
                configure.LicenseKey = null;
                configure.AllowNullCollections = false;
                configure.AllowNullDestinationValues = false;
            },
            [
                typeof(Startup).Assembly,
            ],
            ServiceLifetime.Singleton
        );
    }

    private static void ConfigureAutoMapper(WebApplication app, IWebHostEnvironment env) {
        // do nothing now.
    }

}
