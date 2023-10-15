using netdos.Etc;
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
                    Console.WriteLine("CBreak interpreter: Cannot to execute/compile non .run file!");
                }
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        string[] argument = line.Split(' ', StringSplitOptions.TrimEntries);

                        switch (argument[0])
                        {
                            case "":
                                break;
                            case "fcolor":
                                Console.Clear();
                                int x = Convert.ToInt32(argument[1]);
                                Unenum.foregroundcolor(x);
                                break;
                            case "bcolor":
                                Console.Clear();
                                int y = Convert.ToInt32(argument[1]);
                                Unenum.backgroundcolor(y);
                                break;
                            case "cls":
                                Console.Clear();
                                Console.WriteLine();
                                break;
                            case "echo":
                                Console.WriteLine(terminal.uniteArgs(argument, 1, true));
                                break;
                            case "sleep":
                                int seconds = Convert.ToInt32(argument[1]);
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
                                switch (argument[1])
                                {
                                    case "bsod":
                                        bsoe.Screen("SYSTEM_FILECOMPILE");
                                        break;
                                    case "off":
                                        Cosmos.System.Power.Shutdown();
                                        break;
                                    default:
                                        Console.WriteLine("Error: Can't call the '" + argument[1]+"' block. Reason: Unknown block.");
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