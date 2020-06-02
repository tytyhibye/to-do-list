using BasicAuthentication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Models; // so the application understands what we mean by <ToDoListContext>
using Microsoft.AspNetCore.Identity;

namespace ToDoList
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json"); //this line replaces .AddEnvironmentVariables();
      Configuration = builder.Build();
    }


    public IConfigurationRoot Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddEntityFrameworkMySql()
        .AddDbContext<ToDoListContext>(options => options
        .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));
    
      services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ToDoListContext>()
        .AddDefaultTokenProviders();              
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();// for using static files like images/music/etc
      // must be coded before app.Run or the files won't load.
      
      app.UseDeveloperExceptionPage(); // gives more precise error messages
      
      app.UseAuthentication();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });
 
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Something went wrong!");
      });
    }
  }
    public static class DBConfiguration
  {
    public static string ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list;";
  }
}
