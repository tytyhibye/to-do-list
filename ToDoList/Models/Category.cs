using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Item> Items { get; set; } // Auto-implemented property with Items delcaring the data type as a list
  
    public Category(string categoryName) // The constructor only accepts an argument for categoryName, which is assigned to the Name property.
    {
      Name = categoryName;
      _instances.Add(this);  // All other properties are assigned automatically in the body of the constructor.
      Id = _instances.Count;
      Items = new List<Item>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Category> GetAll()
    {
      return _instances;
    }

    public static Category Find(int searchId)
    {
      return _instances[searchId -1];
    }

    public void AddItem(Item item) // AddItem() will accept an Item object and then use the built-in List Add() method to save that item into the Items property of a specific Category.
    {
      Items.Add(item);
    }
  }
}