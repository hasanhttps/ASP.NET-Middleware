using ASP.NET_Middleware.ActionResults;

namespace ASP.NET_Middleware.Controllers;

public class HomeController : Controller {

    // Methods

    public IActionResult Index() {
        return View();
    }
}