using System;
using System.Collections.Generic;
using System.IO;

namespace netdos
{
    public static class FileEditor
    {
        public static void OpenFile(string path, string name)
        {
            string fullpath = path + name;
            if (File.Exists(fullpath))
            {
                string fullPath = path;

                List<string> buff = new List<string>();

                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Gray;                                                  //
                Console.Write(" Enterstart Notepad                                                     UTF-16  \n");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Editing now: " + name);
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

                    if (curLine == "")
                    {
                        break;
                    }
                    else if (!String.IsNullOrWhiteSpace(curLine)) { buff.Add(curLine); } else { }
                }
                File.WriteAllLines(fullPath, buff.ToArray());
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("File '" + name + "' hass been succesfully changed.");
              
            }
            else
            {
                Console.WriteLine("File '" + name + "' does not exists!");
            }
        }
    }
}