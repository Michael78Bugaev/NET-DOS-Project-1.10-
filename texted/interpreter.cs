using Cosmos.Core;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Threading;
using Cosmos.Core.IOGroup;
using Cosmos.HAL;
using System.Drawing;
using System.Drawing;
using Cosmos.System.Graphics;

namespace netdos
{
    public static class interpreter
    {

        public static void executeProgramm(string path)
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            if (File.Exists(path))
            {
                try
                {
                    if (!path.EndsWith(".com"))
                    {
                        Console.WriteLine("Unavailable to execute non .com file!");
                    }
                    else
                    {
                        string fullPath = path;

                        //Read all lines from file and execute all of them.
                        string[] lines = File.ReadAllLines(fullPath);
                        foreach (string line in lines)
                        {
                            string[] arg = line.Split(' ', StringSplitOptions.TrimEntries);
                            terminal.execute(arg);
                        }
                    }
                }
                catch 
                {
                    bsoe.Screen("TERMINAL_COMMAND_OTHER");
                }
            }
            else
            {
                Console.WriteLine($"File '"+path+"' does not exists!");
            }
            
        }
        public static void editFile(string path)
        {
            int? num = null;
            //Opens .exe editor.
            //TODO: write mew file editor.
            if (File.Exists(path))
            {
                string fullPath = path;

                List<string> buff = new List<string>();

                if (!fullPath.EndsWith(".com"))
                {
                    Console.WriteLine("Can't edit non .com file with com editor!");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Gray;                                                  //
                    Console.Write("DOSNotepad v.1.00 .com editor                                           UTF-8   \n");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Editing now: " + fullPath);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("--------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Black;

                    // Если в файле что-то есть, то тогда пускай показывает содержимое
                    if (File.ReadAllLines(fullPath).Length > 0)                                // НЕ ТРОГАТЬ!!!!!!!!!!!!!!!!!                                                                                                                                                                                                                                                                                                                                                                                        
                    {                                                                           
                        string[] content = File.ReadAllLines(fullPath);
                        foreach (string line in content)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(line);
                            buff.Add(line); 
                        }
                    }

                    // Пускай пишет номер строки и ввод пользователя
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    string curLine = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(curLine)) { buff.Add(curLine); } else { }
                    


                    while (true) // Если что, это бесконечный цикл
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        curLine = Console.ReadLine();
                        if (ConsoleKeyInfo.Equals(ConsoleKey.UpArrow))
                        if (curLine == "")
                        {
                            break;
                        }
                        else if (!String.IsNullOrWhiteSpace(curLine)) { buff.Add(curLine); } else {}
                    }
                    File.WriteAllLines(fullPath, buff.ToArray());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("File '" + fullPath + "' hass been succesfully changed.");
                }
            }
            else
            {
                Console.WriteLine("File '" + path + "' does not exists!");
            }
        }
    }
}
