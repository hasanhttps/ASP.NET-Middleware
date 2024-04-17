using System.Net;
using ASP.NET_Middleware.Middlewares.Abstracts;

namespace ASP.NET_Middleware.Middlewares.Concretes;

public class LoggerMiddleware : IMiddleware{

    // Fields

    public HttpHandler? Next {  get; set; }

    // Methods

    public void Handler(HttpListenerContext context) {
        Console.WriteLine(context.Request.RawUrl);
        Next?.Invoke(context);
        Console.WriteLine("Logged");
    }
}