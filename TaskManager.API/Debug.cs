using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager
{
    public static class Debug
    {
        public static void WriteLine(string txt, ConsoleColor fore, ConsoleColor back)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(txt);
            Console.ResetColor();
        }

        public static void Write(string txt, ConsoleColor fore, ConsoleColor back)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(txt);
            Console.ResetColor();
        }

    }
}
