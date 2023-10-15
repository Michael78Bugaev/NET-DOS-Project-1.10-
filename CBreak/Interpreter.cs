using System;
using System.IO;
using System.Threading;

namespace netdos
{
    public static class CBreakInterpreter
    {
        public static void StartCompile(string path)
        {
            if (File.Exists(path))
            {
                if (!path.EndsWith(".run"))
                {
                    Console.WriteLine("CBreak interpreter: Cannot to execute/compile non .run file!")
                }
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        string[] arg = Console.ReadLine().Split(' ', StringSplitOptions.TrimEntries);

                        switch (arg[0])
                        {
                            case "cls":
                                Console.Clear();
                                Console.WriteLine();
                                break;
                            case "echo":
                                Console.WriteLine(terminal.uniteArgs(arg, 1, true));
                                break;
                            case "sleep":
                                int seconds = Convert.ToInt32(arg[1]);
                                int af = seconds * 1000;
                                Thread.Sleep(af);
                                break;
                            case "goto":
                                Console.ReadLine();
                                break;
                            case "pause":
                                Console.Write("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case "call":
                                switch (arg[1])
                                {
                                    case "bsod":
                                        bsoe.Screen("SYSTEM_FILECOMPILE");
                                        break;
                                    case "off":
                                        Cosmos.System.Power.Shutdown();
                                        break;
                                    default:
                                        Console.WriteLine("Can't call empty system block!");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine(@"The program\command has been stopped. Reason: Unknown command.");
                                break;
                        }
                    }
                }                               
            }
            else
            {
                Console.WriteLine("File '" + path + "' does not exists!");
            }
        }
    }
}