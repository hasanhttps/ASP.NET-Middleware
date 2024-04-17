using System.Net;
using ASP.NET_Middleware.ActionResults;

namespace ASP.NET_Middleware.Controllers;

public class Controller {

    // Fields

    public HttpListenerContext context { get; set; }

    // Methods

   public IActionResult View() {
       ViewResult result = new ViewResult();
       result.ExecuteResult(context);
       return result;
   }  
}