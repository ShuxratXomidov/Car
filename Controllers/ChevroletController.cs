using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers;

public class ChevroletController : Controller
{
    private readonly DataContext dbContext;

    public ChevroletController(DataContext dataContext)
    {
        this.dbContext = dataContext;
    }
    [Authorize]
    
    public IActionResult Index()
    {
        List<Chevrolet> chevrolets = new List<Chevrolet>();
        chevrolets = dbContext.Chevrolets.ToList();

        return View(chevrolets);
    }

    [HttpGet]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Store(Chevrolet chevrolet)
    {
        dbContext.Chevrolets.Add(chevrolet);
        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("[controller]/[action]/{id}")]
    public IActionResult Edit(int id)
    {
        var chevrolet=dbContext.Chevrolets.Find(id);

        return View(chevrolet);
    }

    [HttpPost]
    [Route("[controller]/[action]/{id}")]

    public IActionResult Update(int id, Chevrolet newchevrolet)
    {
        var oldchevrolet=dbContext.Chevrolets.Find(id);
        
        oldchevrolet.Name = newchevrolet.Name;
        oldchevrolet.Year = newchevrolet.Year;
        oldchevrolet.Country = newchevrolet.Country;

        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("[controller]/[action]/{id}")]

    public IActionResult Delete(int id)
    {
        var chevrolet = dbContext.Chevrolets.Find(id);
        dbContext.Chevrolets.Remove(chevrolet);
        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }
}