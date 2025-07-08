using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SysEnvironment = System.Environment;

namespace Beginor.MiniApi.Startup;

public partial class Startup(IConfiguration config, IWebHostEnvironment env) {

    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(
        MethodBase.GetCurrentMethod()!.DeclaringType!
    );

    public void ConfigureServices(IServiceCollection services) {
        logger.Info("Configuring services");
        // app related.
        ConfigureHibernateServices(services, env);
        ConfigureAutoMapperServices(services, env);
        ConfigureAppServices(services, env);
        // web related.
        ConfigurePathBaseServices(services, env);
        ConfigureCustomHeaderServices(services, env);
        ConfigureStaticFilesServices(services, env);
        ConfigureOpenApiServices(services, env);
        // auth
        ConfigureAuthenticationServices(services, env);
        // mvc
        ConfigureMvcServices(services, env);
        logger.Info("Configure services completed!");
    }

    public void Configure(WebApplication app) {
        logger.Info("Configuring application");
        // app related.
        ConfigureHibernate(app, env);
        ConfigureAutoMapper(app, env);
        ConfigureApp(app, env);
        // web related.
        ConfigurePathBase(app, env);
        ConfigureCustomHeader(app, env);
        ConfigureStaticFiles(app, env);
        ConfigureOpenApi(app, env);
        // mvc
        ConfigureAuthentication(app, env);
        ConfigureMvc(app, env);
        logger.Info("Configure application completed!");
    }

    private string? GetAppPathbase() {
        return SysEnvironment.GetEnvironmentVariable(
            "ASPNETCORE_PATHBASE"
        );
    }

}
