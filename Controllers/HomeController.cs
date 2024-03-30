using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Car.Models;

namespace Car.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext dbContext;

    public HomeController(ILogger<HomeController> logger, DataContext dataContext)
    {
        _logger = logger;
        this.dbContext = dataContext;
    }

    public IActionResult Index()
    {
        // AddNewUser();
        return View();
    }

    public void AddNewUser()
    {
        User odam = new User()
        {
            FirstName="Leo",
            LastName="Messi",
            Email="messi@gmail.com",
            Password="123456",
        };
     

        dbContext.Users.Add(odam);
        dbContext.SaveChanges();
       
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
