﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace netdos
{
    public static class bsoe
    {
        public static void Screen(string error)
        {
            string error_code = "0x000";
            if (error == "")                           { error_code = "0x000"; }
            if (error == "SYSTEM_CORE_EX")             { error_code = "1xAA3"; }
            if (error == "TERMINAL_COMMAND_BSOD")      { error_code = "null"; }
            if (error == "KERNEL_EX")                  { error_code = "FxFF8"; }
            if (error == "TERMINAL_COMMAND_OTHER")     { error_code = "0x011"; }
            //if (error == "") { error_code = "0x000"; }
            //if (error == "") { error_code = "0x000"; }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\n");
            Console.Write(@"                                      ");
            Console.BackgroundColor= ConsoleColor.Gray;
            Console.WriteLine(" NET-DOS"); Console.BackgroundColor= ConsoleColor.Blue;
            Console.Write("\n");
            Console.WriteLine($"                 An error has occurred. To return your computer:");
            Console.Write("\n");
            Console.WriteLine(@"                     * Press DEL to reboot your computer");
            Console.WriteLine(@"                     * Back to BIOS, and change settings");
            Console.Write("\n");
            Console.WriteLine($"                                Error code: " + error_code);   // Тут не надо изменять!
            Console.Write("\n");
            Console.Write(@"                            Press any key to continue...");
            Console.ReadKey();
            Cosmos.System.Power.Reboot();
        }
    }
}
