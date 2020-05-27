using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db; // Declares a private and readonly field of type ToDoListContext.

    public ItemsController(ToDoListContext db) // uses dependency injection from addDbContext method in ConfigureServices method in Startup.cs to set the value of our new db property to our ToDoListContext.
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Item> model = _db.Items.ToList(); // replaces GetAll() method (can't use dataset "db.Items" as model for view, hence .ToList())
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Item item)
    {
        _db.Items.Add(item); // runs on DBSet property of DBContext
        _db.SaveChanges(); // runs on DBContext itself
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id) // int id = id of entry we want to view as its sole parameter. Must match property from anonymous object created in ActionLink with code new { id = item.ItemId }
    {
      Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id); // lambda equates to "Start by looking at db.Items (our items table), Then find any items where the ItemId of an item is equal to the id we've passed into this method."
      return View(thisItem);
    }
  }
}