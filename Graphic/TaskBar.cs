using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace netdos.Graphic
{
    public static class TaskBar
    {
        public static void Show(int type)
        {
            switch (type)
            {
                case 0:                                                                                       //
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(DateTime.Now + " |  Terminal                          NET-DOS Global Edition ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    break;
                case 1:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(DateTime.Now + " |  Notepad                           NET-DOS Global Edition ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    break;
            }
        }
    }
}
