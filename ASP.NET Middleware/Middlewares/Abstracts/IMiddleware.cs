using System;
using System.Net;

namespace ASP.NET_Middleware.Middlewares.Abstracts;

public delegate void HttpHandler(HttpListenerContext context);

public interface IMiddleware {

    HttpHandler? Next { get; set; }
    void Handler(HttpListenerContext context);
}    