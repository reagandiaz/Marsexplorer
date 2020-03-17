using System;
using System.Collections.Generic;

namespace Marsexplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> entry = new List<string>();
            entry.Add(Console.ReadLine());
            entry.Add(Console.ReadLine());
            int cnt = int.Parse(entry[0]);
            for (int i = 0; i < cnt; i++)
            {
                entry.Add(Console.ReadLine());
            }
            Console.WriteLine($"=> Explored: {new Robot().Execute(entry.ToArray())}");
        }
    }
}