using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    public Category()
    {
      this.Items = new HashSet<Item>(); // Hashset is an unordered collection of unique elements (more performant than a List but doesnt allow duplicates)
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Item> Items { get; set; } // generic interface - collection of method signatures bundled together.
                  // ICollection required by Entity to outline methods for querying and changing data.
  }
}