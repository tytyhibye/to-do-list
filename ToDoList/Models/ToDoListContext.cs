using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext // inherits/extends from Entity's DbContext for built in functionality
  {
    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; } // needs to know which C# object it's going to represent <Item>

    public ToDoListContext(DbContextOptions options) : base(options) { } // using Startup.cs options via "dependency injection"
  }
}