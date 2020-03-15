using Marsexplorer.Resources;
using System;
using System.Collections.Generic;

namespace Marsexplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Explored:{new Robot().Execute(Console.In.ReadToEnd().Split(System.Environment.NewLine))}");

            bool done = false;
            if (args != null && args.Length == 1)
            {
                try
                {
                    Console.WriteLine($"Explored:{new Robot().ExecuteFromFile(args[0])}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ ex.Message}");
                }
            }
            else
            {
                do
                {
                    try
                    {
                        List<string> entry = new List<string>();
                        entry.Add(Console.ReadLine());
                        entry.Add(Console.ReadLine());
                        int cnt = int.Parse(entry[0]);
                        for (int i = 0; i < cnt; i++)
                        {
                            entry.Add(Console.ReadLine());
                        }
                        Console.WriteLine($"Explored:{new Robot().Execute(entry.ToArray())}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error:{ ex.Message}");
                    }
                    Console.WriteLine("Try Again?[y/n]:");
                    done = Console.ReadLine() != "y";
                } while (!done);
            }
            Console.WriteLine("Thank You!");
        }
    }
}