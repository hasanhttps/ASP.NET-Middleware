using System.Net;
using ASP.NET_Middleware.Middlewares.Abstracts;

namespace ASP.NET_Middleware.Middlewares.Concretes;

public class StaticFileMiddleware : IMiddleware {

    // Fields

    public HttpHandler? Next { get; set; }

    // Methods

    public void Handler(HttpListenerContext context) {
        if (Path.HasExtension(context.Request.RawUrl)) {
            try{
                string? filename = context.Request.RawUrl.Substring(1);
                Console.WriteLine(filename);
                string? path = $"C:\\Users\\hasan\\source\\repos\\ASP.NET Middleware\\ASP.NET Middleware\\Views\\{filename}";
                if (Path.GetExtension(filename) != ".html")
                    path = $"C:\\Users\\hasan\\source\\repos\\ASP.NET Middleware\\ASP.NET Middleware\\wwwroot\\{filename}";

                Console.WriteLine(path);
                var bytes = File.ReadAllBytes(path) ;
                context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                context.Response.ContentType = GetContentType(path);

            }   
            catch (Exception ex) {

            }
        }
        Next?.Invoke(context);
    }

    //public void Handler(HttpListenerContext context)
    //{
    //    Console.WriteLine("File ishledi");
    //    if (Path.HasExtension(context.Request.Url.AbsolutePath))
    //    {
    //        string? path = $"C:\\Users\\hasan\\source\\repos\\ASP.NET Middleware\\ASP.NET Middleware\\Views";
    //        try
    //        {
    //            string? filename = context.Request.Url.AbsolutePath.Substring(1);
    //            path = $"C:\\Users\\hasan\\source\\repos\\ASP.NET Middleware\\ASP.NET Middleware\\Views\\{filename}";
    //            if (Path.GetExtension(filename) != ".html")
    //                path = $"C:\\Users\\hasan\\source\\repos\\Lesson_2_Middleware\\Lesson_2_Middleware\\wwwroot\\{filename}";

    //            var bytes = File.ReadAllBytes(path);
    //            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
    //            context.Response.ContentType = GetContentType(path);
    //            Console.WriteLine("File");
    //        }
    //        catch (Exception ex)
    //        {
    //            path = $"C:\\Users\\hasan\\source\\repos\\Lesson_2_Middleware\\Lesson_2_Middleware\\Views\\404.html";
    //            var bytes = File.ReadAllBytes(path);
    //            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
    //            context.Response.ContentType = GetContentType(path);
    //        }
    //    }
    //    Next?.Invoke(context);
    //}


    private string GetContentType(string path)
    {
        string contentType = "text/html";
        switch (Path.GetExtension(path))
        {
            case ".css":
                contentType = "text/css";
                break;
            case ".js":
                contentType = "text/javascript";
                break;
            case ".jpg":
                contentType = "image/jpg";
                break;
            case ".png":
                contentType = "image/png";
                break;
            case ".json":
                contentType = "application/json";
                break;
            case ".xml":
                contentType = "application/xml";
                break;
            case ".pdf":
                contentType = "application/pdf";
                break;
        }
        return contentType;
    }
}