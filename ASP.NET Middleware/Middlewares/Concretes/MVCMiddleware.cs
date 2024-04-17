using System.Net;
using System.Reflection;
using ASP.NET_Middleware.Controllers;
using ASP.NET_Middleware.Middlewares.Abstracts;

namespace ASP.NET_Middleware.Middlewares.Concretes;

public class MVCMiddleware: IMiddleware {

    // Fields

    public HttpHandler? Next { get; set; }   

    // Methods

    public void Handler(HttpListenerContext context) {

        var url = context.Request.Url?.AbsolutePath.Split("/", StringSplitOptions.RemoveEmptyEntries);
        var controllerName = $"ASP.NET_Middleware.Controllers.{url[0]}Controller";

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type? type = assembly.GetType(controllerName);

        if (type is not null) {
            var controllerOBJ = Activator.CreateInstance(type) as Controller;

            if (controllerOBJ is not null) {
                var actionName = url[1];
                MethodInfo? action = type.GetMethod(actionName);
                if (action is not null) { 
                    controllerOBJ.context = context;
                    action.Invoke(controllerOBJ, null);
                }
            }
        }
        Next?.Invoke(context);
    }
}
