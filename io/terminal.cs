using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Cosmos.Core;
using Sys = Cosmos.System;
using System.ComponentModel.Design;
using System.Threading;

namespace netdos
{
    public static class terminal
    {
        public static void execute(string[] arg)
        {
            
            if (!arg[0].EndsWith(".com"))
            {
                arg[0] = arg[0].ToLower();
            }
            else
            {

            }

            switch (arg[0])
            {
                case "sleep":
                    int delay = Convert.ToInt32(arg[1]);
                    Thread.Sleep(delay);
                    break;
                case "ver":
                    interpreter.executeProgramm(@"0:\System\Apps\Version.com");
                    break;
                case "pause":
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "write":
                    if (!String.IsNullOrEmpty(arg[1]))
                    {
                        if (arg[1].StartsWith("$"))
                        {
                            switch (arg[1])
                            {
                                case "$dos":
                                    Console.WriteLine("easter egg!");
                                    break;
                                default:
                                    while (true)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Magenta;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(2500, 2);
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(1345, 2);
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(9765, 2);
                                        Console.BackgroundColor = ConsoleColor.Green;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(1234, 2);
                                        Console.BackgroundColor = ConsoleColor.Yellow;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(2642, 2);
                                        Console.BackgroundColor = ConsoleColor.Cyan;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(7845, 2);
                                        Console.BackgroundColor = ConsoleColor.Gray;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(52, 2);
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(976, 2);
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.Clear();
                                        Sys.PCSpeaker.Beep(5842, 2);
                                    }
                            }
                        }
                        else
                        {
                            Console.Write(uniteArgs(arg, 1, true));
                        }
                    }
                    else
                    {
                        Console.Write("");
                    }
                    break;
                case "mf":
                    if (!File.Exists(FS.curPath + arg[1]))
                    {
                        File.Create(FS.curPath + arg[1]);
                    }
                    else
                    {
                        Console.WriteLine("File '" + arg[1] + "' has already exist!");
                    }
                    break;
                case "df":
                    if (File.Exists(FS.curPath + arg[1]))
                    {
                        File.Delete(FS.curPath + arg[1]);
                    }
                    else
                    {
                        Console.WriteLine("File '" + arg[1] + "' does not exist!");
                    }
                    break;
                case "md":
                    if (!Directory.Exists(FS.curPath + arg[1]))
                    {
                        Directory.CreateDirectory(FS.curPath + arg[1]);
                    }
                    else
                    {
                        Console.WriteLine("Directory '" + arg[1] + "' has already exist!");
                    }
                    break;
                case "dd":
                    try
                    {
                        if (Directory.Exists(FS.curPath + arg[1]))
                        {
                            Directory.Delete(FS.curPath + arg[1]);
                        }
                        else
                        {
                            Console.WriteLine("Directory '" + arg[1] + "' does not exist!");
                        }
                    } 
                    catch
                    {
                        bsoe.Screen("TERMINAL_COMMAND_OTHER");
                    }
                    break;
                case "root":
                    FS.curPath = @"0:\";
                    break;
                case "edit":
                    interpreter.editFile(FS.curPath + arg[1]);
                    break;
                case "up":
                    goUp();
                    break;
                case "shutdown":
                    Cosmos.System.Power.Shutdown();
                    break;
                case "reboot":
                    Cosmos.System.Power.Reboot();
                    break;
                case "bsod":
                    bsoe.Screen("TERMINAL_COMMAND_BSOD");
                    break;
                case "dir":
                    dir(FS.curPath);                  
                    break;
                case "cd":
                    changeDir(arg[1]);
                    break;
                case "writeline":
                    Console.WriteLine(uniteArgs(arg, 1, true));
                    break;
                case "help":
                    interpreter.executeProgramm(@"0:\System\Apps\Help.com");
                    break;
                case "clear":
                    Console.Clear();
                    Console.Write("\n");
                    break;
                default:
                    try
                    {
                        //if (arg[1] == "=")
                        //{
                        //    string name = arg[0];
                        //    if (arg[2] == "goto")
                        //    {
                        //        name = Console.ReadLine();
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Error: The variable '" + name + "' has not been assigned a value.");
                        //    }
                        //}
                        if (arg[0].EndsWith(".com"))
                        {
                            interpreter.executeProgramm(FS.curPath + arg[0]);
                        }
                        else
                        {
                            Console.WriteLine("Unknown command, or executable file.\n");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Unknown command, or executable file.\n");
                    }
                    
                    break;
            }
        }
        public static void changeDir(string dirName)
        {
            if (!String.IsNullOrEmpty(dirName))
            {
                string path = FS.curPath + dirName;
                if (Directory.Exists(path))
                {
                    FS.curPath = path + @"\";
                }
                else
                {
                    Console.WriteLine("Directory '" + path + "' doesn't exist!");
                }
            }
            else
            {
                Console.WriteLine(FS.curPath + "\n");
            }
        }
        public static void goUp()
        {
            if (FS.curPath != @"0:\")
            {
                if (Directory.GetParent(FS.curPath).Equals(@"0:\"))
                {
                    FS.curPath = Directory.GetParent(FS.curPath).FullName;
                }
                else
                {
                    FS.curPath = Directory.GetParent(FS.curPath).FullName + @"\";
                }
            }
            else
            {
                Console.WriteLine("Error: Can't go upper than root folder!");
                FS.curPath = @"0:\";
            }
        }
        public static void dir(string path)
        {
            var files_list = Directory.GetFiles(path);
            var directory_list = Directory.GetDirectories(path);

            Console.WriteLine("");

            foreach (var file in files_list) 
            {
                if (file.EndsWith(".com"))
                {
                    Console.WriteLine(" <COM>   " + file);
                }
                else if (file.EndsWith(".txt"))
                {
                    Console.WriteLine(" <TXT>   " + file);
                }
                else
                {
                    Console.WriteLine(" <FILE>  " + file);
                }
                
            }
            foreach (var directory in directory_list)
            {
                Console.WriteLine(" <DIR>   " + directory);
            }
            Console.WriteLine(" ");
        }
        static string uniteArgs(string[] arg, int argsToRemove, bool addSpace)
        {
            for (int x = 0; x != arg.Length; x++)
            {
                arg[x] += " ";
            }
            for (int x = 0; x != argsToRemove; x++)
            {
                arg[x] = "";
            }
            return string.Concat(arg);
        }
    }
}
