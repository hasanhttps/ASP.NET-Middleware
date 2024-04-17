using System.Net;

namespace ASP.NET_Middleware.Middlewares.Abstracts;

public delegate void HttpHandler(HttpListenerContext context);

public interface IMiddleware {
    
    // Methods

    public HttpHandler? Next { get; set; }

    // Methods

    void Handler(HttpListenerContext context);
}    