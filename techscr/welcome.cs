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
            Console.WriteLine("=============================================");
            Console.WriteLine("||      NET-DOS v.1.00 Global Edition        ||");
            Console.WriteLine("||            _______________                ||");
            Console.WriteLine("||            |0|1|0|1|1|0|1|                ||");
            Console.WriteLine("||            ---------------                ||");
            Console.WriteLine("===============================================");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
