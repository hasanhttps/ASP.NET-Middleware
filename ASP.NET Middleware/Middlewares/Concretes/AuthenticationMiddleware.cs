using System.Net;
using ASP.NET_Middleware.Middlewares.Abstracts;

namespace ASP.NET_Middleware.Middlewares.Concretes;

public class AuthenticationMiddleware : IMiddleware {

    // Fields

    public HttpHandler? Next { get; set; }

    // Methods

    public void Handler(HttpListenerContext context) {

        string? username = context.Request.QueryString["username"];
        string? password = context.Request.QueryString["password"];

        Next?.Invoke(context);
    }
}