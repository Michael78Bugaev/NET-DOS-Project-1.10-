using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netdos.techscr
{
    public static class welcome
    {
        public static void Screen()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("========================================================");
            Console.WriteLine("||            NET-DOS v.1.00 Global Edition           ||");
            Console.WriteLine("||  Welcome to new operating system by                ||");
            Console.WriteLine("||  Enterstart Company! Write 'help' to get           ||");
            Console.WriteLine("||  list of commands! (Don't forget about readme.txt!)||");
            Console.WriteLine("========================================================");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
