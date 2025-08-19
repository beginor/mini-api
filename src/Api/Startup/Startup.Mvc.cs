using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

namespace Beginor.MiniApi.Startup;

partial class Startup {

    private void ConfigureMvcServices(IServiceCollection services, IWebHostEnvironment env) {
        services.AddControllers()
            .ConfigureApplicationPartManager(apm => {
                apm.ApplicationParts.Clear();
                apm.ApplicationParts.Add(
                    new AssemblyPart(typeof(Startup).Assembly)
                );
            })
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
