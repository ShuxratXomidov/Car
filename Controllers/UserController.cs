using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers;

public class UserController : Controller
{
    private readonly DataContext dbContext;

    public UserController(DataContext dataContext)
    {
        this.dbContext = dataContext;
    }
    [Authorize]
    public IActionResult Index()
    {
        List<User> users = new List<User>();
        users = dbContext.Users.ToList();

        return View(users);
    }

    public IActionResult Store(User odam)
    {
        dbContext.Users.Add(odam);
        dbContext.SaveChanges();

        return RedirectToAction("Index");

    }
}