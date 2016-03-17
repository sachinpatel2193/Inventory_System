using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment2
{
    class Program
    {
        static void execute()
        {
            StoreOperations s = new StoreOperations();
            Console.WriteLine("Welcome to IMS-Inventory Management System");
            Console.WriteLine("Type ? for help");
            while (true)
            {
                Console.Write("<prompt>");
                string line = Console.ReadLine();
                string[] words = line.Split(' ');
                
                switch (words[0])
                {
                    case "?":
                    case "help":
                        s.Help();
                        break;
                    case "lf":
                    case "listfiles":
                        s.listfiles();
                        break;
                    case "ldb":
                    case "loaddb":
                        try {
                            s.loaddb(words[1]);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid no of arguments."+
                                " Index was outside the bounds of the array.");
                        }
                        break;
                    case "sdb":
                    case "savedb":
                        try { 
                        s.savedb(words[1]);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid no of arguments."+
                                " Index was outside the bounds of the array.");
                        }
                        break;
                    case "q":
                    case "quit":
                        s.quit();
                        return;
                    case "li":
                    case "lstitems":
                        s.listitems();
                        break;
                    case "+":
                    case "inc":
                        try { 
                        s.inc(Convert.ToInt32(words[1]), Convert.ToInt32(words[2]));
                        }
                        catch
                        {

                            Console.WriteLine("Invalid no of arguments."+
                                " Index was outside the bounds of the array.");
                        }
                        break;
                    case "-":
                    case "dec":
                        try { 
                        s.dec(Convert.ToInt32(words[1]), Convert.ToInt32(words[2]));
                        }
                        catch
                        {

                            Console.WriteLine("Invalid no of arguments."+
                                " Index was outside the bounds of the array.");
                        }
                        break;
                    case "lw":
                    case "low":
                        s.low();
                        break;
                    case "pk":
                    case "prek":
                        try
                        {
                        s.prek(Convert.ToInt32(words[1]));
                        }
                        catch
                        {

                            Console.WriteLine("Invalid no of arguments."+
                                " Index was outside the bounds of the array.");
                        }
                        break;
                    default:
                        Console.WriteLine("Command {0} is not recognized."+
                            " Please try again.",words[0]);
                        break;
                }
            }
        }
        
        static void Main(string[] args)
        {
            execute();
            Console.ReadKey();
        }
    }
}
