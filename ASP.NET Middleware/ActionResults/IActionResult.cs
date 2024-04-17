using System;
using System.Net;

namespace ASP.NET_Middleware.ActionResults;

public interface IActionResult {

    // Methods

    void ExecuteResult(HttpListenerContext context); 
}