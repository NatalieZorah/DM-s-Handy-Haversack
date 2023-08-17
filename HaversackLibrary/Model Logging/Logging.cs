using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaversackLogic
{
    public class Logging
    {
        public static void TestMessage(object? value)
        {
            Console.WriteLine($"[TEST INFO] {value}\n");
        }

        public static void TestMessage(string msg)
        {
            Console.WriteLine($"[TEST INFO] {msg}");
        }

        public static void TestMessage(bool msg)
        {
            Console.WriteLine($"[TEST INFO] [bool] {msg}");
        }


    }
}
