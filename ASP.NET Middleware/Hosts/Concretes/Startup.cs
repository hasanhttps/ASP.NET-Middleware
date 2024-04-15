using System;
using ASP.NET_Middleware.Hosts.Abstracts;
using ASP.NET_Middleware.Middlewares.Concretes;

namespace ASP.NET_Middleware.Hosts.Concretes;

public class Startup: IStartup {
    
    // Methods

    public void Configure(MiddlewareBuilder builder) {

        builder.UseMiddleware<LoggerMiddleware>();
        builder.UseMiddleware<AuthenticationMiddleware>();
        builder.UseMiddleware<StaticFileMiddleware>();
    }

}