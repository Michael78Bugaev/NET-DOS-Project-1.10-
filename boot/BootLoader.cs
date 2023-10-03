using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace netdos
{
    public static class BootLoader
    {
        public static void Boot()
        {
            if (!Directory.Exists(@"0:\System\User"))
                Load();
            else
            {

            }

        }
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Setting up NET-DOS...");

            Directory.CreateDirectory(@"0:\System");
            Directory.CreateDirectory(@"0:\System\Apps");
            Directory.CreateDirectory(@"0:\System\Logs");
            Directory.CreateDirectory(@"0:\System\Params");
            Directory.CreateDirectory(@"0:\System\User");

            File.Create(@"0:\System\Logs\doNotif");

            
            File.Delete(@"0:\test\DirInTest\Readme.txt");
            File.Delete(@"0:\Kudzu.txt");
            File.Delete(@"0:\Root.txt");
            Directory.Delete(@"0:\test\DirInTest");
            Directory.Delete(@"0:\test");
            Directory.Delete(@"0:\Dir Testing");

            string[] helpToWrite = {
                                "writeLine NET-DOS Help list 1",
                                "writeLine mf [name]___________________________create file",
                                "writeLine df [name]___________________________delete file",
                                "writeLine md [name]___________________________create dir",
                                "writeLine dd [name]___________________________delete dir",
                                "writeLine dir_________________________________displays containing of current directory",
                                "writeLine cd [name]___________________________change dir",
                                @"writeLine root_______________________________go to 0:\ directory",
                                "writeLine up__________________________________go to upper directory",
                                "writeLine edit [name]_________________________.com editor. Empty string + enter to exit",
                                "writeLine [name].com__________________________execute .com file",
                                "writeLine write [text]________________________write text to console",
                                "writeLine writeLine [text]____________________write line to console",
                                "writeLine shutdown____________________________turn off computer",
                                "writeLine ver_________________________________version of NET-DOS",
                                "writeline sleep [milseconds]__________________sleep in milleseconds",
                                "writeLine pause_______________________________wait for any key to be pressed",
                                "pause"};
            File.Create(@"0:\System\Apps\Help.com");
            File.WriteAllLines(@"0:\System\Apps\Help.com", helpToWrite);
            string[] versiontowrite =
            {
                "writeline NET-DOS (C) v.1.10",
                "writeline Enterstart (C) Company 2023"
            };
            File.Create(@"0:\System\Apps\Version.com");
            File.WriteAllLines(@"0:\System\Apps\Version.com", versiontowrite);
            Cosmos.System.Power.Reboot();
        }

    }
}
