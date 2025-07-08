using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Beginor.AppFx.Core;
using Beginor.AppFx.Logging.Log4net;

namespace Beginor.MiniApi;

public static class Program {

    public static void Main(string[] args) {
        AddGlobalConverters();
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(Path.Combine("config", "appsettings.json"), true, true)
            .AddJsonFile(Path.Combine("config", $"appsettings.{builder.Environment.EnvironmentName}.json"), true, true)
            .AddEnvironmentVariables()
            .AddCommandLine(args);
        builder.Logging
            .ClearProviders()
            .AddLog4net(Path.Combine("config", "log.config"));
        var section = builder.Configuration.GetSection("kestrel");
        if (section.Exists()) {
            builder.Services.Configure<KestrelServerOptions>(section);
        }
        var startup = new Startup.Startup(builder.Configuration, builder.Environment);
        startup.ConfigureServices(builder.Services);
        var app = builder.Build();
        startup.Configure(app);
        app.Run();
    }

    private static void AddGlobalConverters() {
        System.ComponentModel.TypeDescriptor.AddAttributes(
            typeof(System.Net.IPAddress),
            new System.ComponentModel.TypeConverterAttribute(typeof(IPAddressConverter))
        );
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

}
