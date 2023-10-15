using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netdos.Network.QIP
{
    public static class QuickInstallPackages
    {
        enum pack
        {
            update = 21,

        }
        public static void Install(string package)
        {
            switch (package)
            {
                case "update":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Checking updates...");
                    Console.ForegroundColor= ConsoleColor.Gray;
                    break;
            }
        }
    }
}
