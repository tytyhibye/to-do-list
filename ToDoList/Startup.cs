using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }


    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage(); // gives more precise error messages
      
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });

      app.UseStaticFiles(); // for using static files like images/music/etc
      // must be coded before app.Run or the files won't load.
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