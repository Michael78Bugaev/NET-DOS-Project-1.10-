using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netdos.Boot
{
    public static class Bootscreen
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine(" NET-DOS Global Edition Setup Manager");
            Console.Write    ("======================================");
            Console.SetCursorPosition(6, 7);
            Console.Write("Welcome to Enterstart DOS Setup Manager! There is new features:");
            

        }
    }
}
