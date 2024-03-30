using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers;

public class KiaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}