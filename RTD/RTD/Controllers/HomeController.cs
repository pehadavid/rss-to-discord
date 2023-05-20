using Microsoft.AspNetCore.Mvc;

namespace RTD.Controllers;

public class HomeController : Controller
{
    // GET
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}