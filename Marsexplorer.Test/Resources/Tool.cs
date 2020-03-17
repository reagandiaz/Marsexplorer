using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marsexplorer.Test.Resources
{
    public class Tool
    {
        public static void Move(List<string> moves, int ex)
        {
            int count = moves.Count;
            moves.Insert(0, $"0 0");
            moves.Insert(0, $"{count}");
            int r1 = new Robot().Execute(moves.ToArray());
            Assert.AreEqual(ex, (object)r1, $"{r1}:{ex}");
        }

        public static void Compare(string dir, string f1, string f2)
        {
            string p = @"C:\Users\jseeg\source\repos\Marsexplorer\bin\Debug\netcoreapp3.1";
            int r1 = new Robot().ExecuteFromFile($"{p}\\{dir}\\{f1}.txt");
            int r2 = new Robot().ExecuteFromFile($"{p}\\{dir}\\{f2}.txt");
            Assert.AreEqual((object)r1, (object)r2, $"{f1}:{f2}");
        }

        public static void Single(string dir, string f1, int ex)
        {
            string p = @"C:\Users\jseeg\source\repos\Marsexplorer\bin\Debug\netcoreapp3.1";
            string a = $"{p}\\{dir}\\{f1}.txt";
            int r1 = new Robot().ExecuteFromFile($"{p}\\{dir}\\{f1}.txt");
            Assert.AreEqual((object)ex, (object)r1, $"{f1}");
        }
    }
}
