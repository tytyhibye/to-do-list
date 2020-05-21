using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {


    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategores);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>(); // Create a new Dictionary called model because a Dictionary can hold multiple key-value pairs.
      Category selectedCategory = Category.Find(id);
      List<Item> categoryItems = selectedCategory.Items; // Add both the Category and its associated Items to this Dictionary.
      model.Add("category", selectedCategory); // These will be stored with the keys "category" and "items".
      model.Add("items", categoryItems);
      return View(model); // The Dictionary, which is named model, will be passed into View().
    }
  }
}