using System;
using System.Threading;

namespace DataStructureProject_1
{
  
    public class Program
    {

        static void Main(string[] args)
        {
           
            
            while (true)
            {
                Console.Clear();
                UI.PrintLineMenu("Select : ");
                UI.PrintLine("> 1. Programs implemented with stack");
                UI.PrintLine("> 2. Programs implemented with Linked List");
                try
                {
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    {
                        ApplicationStack app = new ApplicationStack();
                        app.Run();
                        Console.CancelKeyPress += app.Console_CancelKeyPress;
                    }
                    else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    {
                        ApplicationLinkedList app = new ApplicationLinkedList();
                        app.Run();
                        Console.CancelKeyPress += app.Console_CancelKeyPress;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message != "0")
                        return;
                }
            }
        }
    }
}
