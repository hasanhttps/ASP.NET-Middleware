using System.Net;

namespace ASP.NET_Middleware.ActionResults;

public class ViewResult : IActionResult {

    //Methods

    public void ExecuteResult(HttpListenerContext context) {
        var section = context.Request.Url?.AbsolutePath.Split("/", StringSplitOptions.RemoveEmptyEntries);

        var folderName = section[0];
        var fileName = section[1];

        var path = $"{Directory.GetCurrentDirectory().Split("bin"[0])}/Views/{folderName}/{fileName}.html";

        if (File.Exists(path)) { 
            var bytes = File.ReadAllBytes(path);
            context.Response.ContentType = "text/html";
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            Console.WriteLine("Readed");
            Console.WriteLine(bytes);
        }
    }
}