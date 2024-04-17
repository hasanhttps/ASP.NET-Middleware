using System.Net;
using ASP.NET_Middleware.Hosts.Abstracts;
using ASP.NET_Middleware.Middlewares.Abstracts;
using ASP.NET_Middleware.Middlewares.Concretes;

namespace ASP.NET_Middleware.Hosts.Concretes;

public class WebHost {

    // Fields

    private int _port;
    private HttpListener _listener;
    private HttpHandler _requestHandler;
    private MiddlewareBuilder _builder = new MiddlewareBuilder();

    // Constructors

    public WebHost(int port) { 
        _port = port;
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://localhost:{_port}/");
    }

    // Methods

    public void UseStartup<T>() where T : IStartup, new() { // new() objecti yaradila bilen demekdir. Abstract classlara icaze vermir.
        var startup = new T();
        startup.Configure(_builder);

        _requestHandler = _builder.Build();
    }

    public void Run() {
        _listener.Start();
        Console.WriteLine($"Server started on {_port}.");

        while (true) {
            var context = _listener.GetContext();
            Task.Run(() => {
                _requestHandler.Invoke(context);
                //context.Response.Close();
            });
        }
    }
}
