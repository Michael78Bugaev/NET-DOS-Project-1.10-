using System;
using System.Data;

namespace netdos.Etc
{
    public static class Unenum
    {
        public static void foregroundcolor(int color)
        {
            switch (color)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }
        public static void backgroundcolor(int color)
        {
            switch (color)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;  
                case 1:     
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;  
                case 2:     
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;  
                case 3:     
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;  
                case 4:     
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;  
                case 5:     
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;  
                case 6:     
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;  
                case 7:     
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
        }

    }
}