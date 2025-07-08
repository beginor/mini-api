using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Beginor.MiniApi;

partial class Startup {

    private void ConfigureOpenApiServices(IServiceCollection services, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
            services.AddOpenApi();
        }
    }

    private void ConfigureOpenApi(WebApplication app, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
            app.MapOpenApi();
        }
    }

}
