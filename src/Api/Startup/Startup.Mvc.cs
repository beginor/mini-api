using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Beginor.MiniApi.Startup;

partial class Startup {

    private void ConfigureMvcServices(IServiceCollection services, IWebHostEnvironment env) {
        services.AddControllers()
            .AddControllersAsServices()
            .ConfigureApiBehaviorOptions(options => {
                options.SuppressConsumesConstraintForFormFileParameters = false;
                options.SuppressInferBindingSourcesForParameters = false;
                options.SuppressModelStateInvalidFilter = false;
            });
    }

    private void ConfigureMvc(WebApplication app, IWebHostEnvironment env) {
        app.MapControllers();
    }

}
