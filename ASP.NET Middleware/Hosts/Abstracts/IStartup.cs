using System;
using ASP.NET_Middleware.Middlewares.Concretes;

namespace ASP.NET_Middleware.Hosts.Abstracts;

public interface IStartup {

    // Methods

    public void Configure(MiddlewareBuilder builder);
}