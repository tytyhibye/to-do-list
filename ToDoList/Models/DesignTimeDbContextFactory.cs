using BasicAuthentication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ToDoList.Models
{
  public class ToDoListContextFactory : IDesignTimeDbContextFactory<ToDoListContext>
  {

    ToDoListContext IDesignTimeDbContextFactory<ToDoListContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<ToDoListContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new ToDoListContext(builder.Options);
    }
  }
}

// At design-time, derived DbContext instances can be created in order to enable specific 
// design-time experiences such as Migrations. Design-time services will automatically
// discover implementations of this interface that are in the startup assembly or the
// same assembly as the derived context.