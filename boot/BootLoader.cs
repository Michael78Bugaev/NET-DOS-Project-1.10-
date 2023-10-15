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
            try
            {
                if (Directory.Exists(@"0:\System"))
                {
                    Console.Clear();
                    Console.WriteLine("Hello! We detected an old version of NET-DOS!");
                    Console.WriteLine("Do you want to delete NET-DOS v.1.00 and install NET-DOS Global Edition? [Y/N]");
                    Console.Write(">");
                    var key = Console.ReadLine();
                    switch (key)
                    {
                        case "y":
                            if (!Directory.Exists(@"0:\SYS"))
                            {
                                Console.Clear();
                                Console.WriteLine("Ok! Deleting NET-DOS v.1.00...");
                                File.Delete(@"0:\System\Apps\Version.com");
                                File.Delete(@"0:\System\Apps\Help.com");
                                Directory.Delete(@"0:\System\Apps");
                                Directory.Delete(@"0:\System\Logs");
                                Directory.Delete(@"0:\System\Params");
                                Directory.Delete(@"0:\System\User");
                                Directory.Delete(@"0:\System");
                                Load();
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case "n":
                            Cosmos.System.Power.Shutdown();
                            break;
                        case "Y":
                            if (!Directory.Exists(@"0:\SYS"))
                            {
                                Console.Clear();
                                Console.WriteLine("Ok! Deleting NET-DOS v.1.00...");
                                Directory.Delete(@"0:\System\Apps");
                                File.Create(@"0:\System\Apps\Version.com");
                                File.Create(@"0:\System\Apps\Help.com");
                                Directory.Delete(@"0:\System\Logs");
                                Directory.Delete(@"0:\System\Params");
                                Directory.Delete(@"0:\System\User");
                                Directory.Delete(@"0:\System");
                                Load();
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case "N":
                            Cosmos.System.Power.Shutdown();
                            break;
                    }
                }
                else if (!Directory.Exists(@"0:\SYS"))
                {
                    Load();
                }
            }
            catch
            {
                bsoe.Screen("BOOT_FAILURE");
            }
        }
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Setting up NET-DOS Global Edition... Don't turn off your computer!");

            Directory.CreateDirectory(@"0:\SYS");
            Directory.CreateDirectory(@"0:\SYS\Apps");
            Directory.CreateDirectory(@"0:\SYS\Logs");
            Directory.CreateDirectory(@"0:\SYS\Params");
            Directory.CreateDirectory(@"0:\SYS\User");

            File.Create(@"0:\SYS\Logs\doNotif");

            if (Directory.Exists(@"0:\test"))
            {
                File.Delete(@"0:\test\DirInTest\Readme.txt");
                File.Delete(@"0:\Kudzu.txt");
                File.Delete(@"0:\Root.txt");
                Directory.Delete(@"0:\test\DirInTest");
                Directory.Delete(@"0:\test");
                Directory.Delete(@"0:\Dir Testing");
            }
            string[] readmetxt =
            {
                "NET-DOS Global Edition - What's new?",
                " * A new command - sleep (millseconds)",
                " * A new programming language - CBreak!",
                " * Optimizing programs",
                " * A new universal file editor - Enterstart Notepad",
                "",
                "Example CBreak program:",
                "",
                "echo Hello, world!",
                "pause",
                "echo bsod testing?",
                "goto",
                "bsod"
            };
            File.Create(@"0:\readme.txt");
            File.WriteAllLines(@"0:\readme.txt", readmetxt);
            string[] helpToWrite = {
                                "echo NET-DOS Global Edition Help list ",
                                "echo mf [name]___________________________create file",
                                "echo df [name]___________________________delete file",
                                "echo md [name]___________________________create dir",
                                "echo dd [name]___________________________delete dir",
                                "echo dir_________________________________displays containing of current directory",
                                "echo cd [name]___________________________change dir",
                               @"echo root________________________________go to 0:\ directory",
                                "echo up__________________________________go to upper directory",
                                "echo edit [name]_________________________.com editor. Empty string + enter to exit",
                                "echo [name].com__________________________execute .com file",
                                "echo write [text]________________________write text to console",
                                "echo writeLine [text]____________________write line to console",
                                "echo shutdown____________________________turn off computer",
                                "echo ver_________________________________version of NET-DOS",
                                "echo sleep [milseconds]__________________sleep in milleseconds",
                                "echo pause_______________________________wait for any key to be pressed",
                                "pause"};
            string[] versiontowrite =
            {
                "writeline NET-DOS (C) Global Edition",
                "writeline Enterstart (C) Company 2023",
                "Run only in Virtual Machine!!!"
            };
            File.Create(@"0:\SYS\Apps\Help.run");
            File.WriteAllLines(@"0:\SYS\Apps\Help.run", helpToWrite);
            File.Create(@"0:\SYS\Apps\Version.com");
            File.WriteAllLines(@"0:\SYS\Apps\Version.run", versiontowrite);
            Cosmos.System.Power.Reboot();
        }

    }
}
