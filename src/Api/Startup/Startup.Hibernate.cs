using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using NHibernate.Extensions.NetCore;
using NHEnv = NHibernate.Cfg.Environment;

namespace Beginor.MiniApi.Startup;

partial class Startup {

    private void ConfigureHibernateServices(IServiceCollection services, IWebHostEnvironment env) {
        var cfg = new Configuration();
        var configFile = Path.Combine("config", "hibernate.config");
        cfg.Configure(configFile);
        var isDevelopment = env.IsDevelopment().ToString();
        cfg.SetProperty(NHEnv.ShowSql, isDevelopment);
        cfg.SetProperty(NHEnv.FormatSql, isDevelopment);
        cfg.AddAttributeMappingAssembly(typeof(Startup).Assembly);
        services.AddHibernate(cfg);
    }

    private void ConfigureHibernate(WebApplication app, IWebHostEnvironment env) {
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
        loggerFactory.UseAsHibernateLoggerFactory();
    }

}

public static class ConfigurationExtensions {

    public static Configuration AddAttributeMappingAssembly(this Configuration cfg, Assembly assembly) {
        HbmSerializer.Default.Validate = true;
        var stream = HbmSerializer.Default.Serialize(assembly);
        using var reader = new StreamReader(stream);
        var xml = reader.ReadToEnd();
        cfg.AddXml(xml);
        return cfg;
    }

}
