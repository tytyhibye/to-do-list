using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace ToDoList
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();
      
      host.Run();
    }
  }
}     
      // bool run = true;
      // while(run == true)
      // {
      // Start:
      // List<Item> toDoList = new List<Item>{};
      // Console.WriteLine("Welcome to your To-Do List!\n\nWould you like to:\n\t1) View your list.\n\t2) Add to your list.\n\t3) Clear your ToDo List(Good for you!)\n\t4) Exit Program.\n\n[ 1 / 2 / 3 / 4 ]");
      // string userInput = Console.ReadLine();
      // if (userInput == "1")
      // {
      //   List:
      //   Console.WriteLine("Your To-Do List:\n\n");
      //   List<Item> fullList = Item.GetAll();
      //   foreach (Item theseItems in fullList)
      //   { 
      //     Console.WriteLine(theseItems.Description);
      //   }
      //   System.Threading.Thread.Sleep(3000); // timeout
      //   Console.WriteLine("\nDo you want to go back to main menu? [ Y / N ]");
      //   string menuInput = (Console.ReadLine().ToLower());
      //   if (menuInput == "y")
      //   {
      //   goto Start;
      //   }
      //   else if (menuInput == "n")
      //   {
      //     goto List;
      //   }
      // }
      // else if (userInput == "2")
      // {
      //   Console.WriteLine("Please write out your task:");
      //   string task = Console.ReadLine();
      //   Item newItem = new Item(task);
      //   goto Start;
      // }
      // else if (userInput == "3")
      // {
      //   Item.ClearAll();
      //   goto Start;
      // }
      // else if (userInput == "4")
      // {
      //   run = false;
      // }
      // }