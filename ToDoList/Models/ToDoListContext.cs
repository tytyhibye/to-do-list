using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace BasicAuthentication.Models
{
  public class ToDoListContext : IdentityDbContext<ApplicationUser> 
  {
    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; } // needs to know which C# object it's going to represent <Item>
    public DbSet<CategoryItem> CategoryItem { get; set; }
    public ToDoListContext(DbContextOptions options) : base(options) { } // using Startup.cs options via "dependency injection"
  }
}