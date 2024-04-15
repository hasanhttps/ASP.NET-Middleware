using ASP.NET_Middleware.Hosts.Concretes;

WebHost host = new(27001);
host.UseStartup<Startup>();
host.Run();