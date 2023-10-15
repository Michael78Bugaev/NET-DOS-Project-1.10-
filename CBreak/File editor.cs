using Cosmos.Core;
using netdos.Etc;
using netdos.Graphic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace netdos
{
    public static class FileEditor
    {
        private static string ReadLineOrEsc(string path)
        {
            string retString = "";
            List<string> buff = new List<string>();

            int curIndex = 0;
            ConsoleKeyInfo readKeyResult = Console.ReadKey(true);

            switch (readKeyResult.Key)
            {
                case ConsoleKey.Escape:
                    esc(path);
                    break;
                case ConsoleKey.Enter:
                    Console.WriteLine();
                    buff.Add(readKeyResult.Key.ToString());
                    return retString;
                case ConsoleKey.Backspace:
                    if (curIndex > 0)
                    {
                        retString = retString.Remove(retString.Length - 1);
                        Console.Write(readKeyResult.KeyChar);
                        Console.Write(' ');
                        Console.Write(readKeyResult.KeyChar);
                        curIndex--;
                    }
                    break;
                default:
                    retString += readKeyResult.KeyChar;
                    Console.Write(readKeyResult.KeyChar);
                    curIndex++;
                    break;
            }
            return retString;
        }
        public static void Start(string path)
        {
            string fullPath = path;
            List<string> buff = new List<string>();
            string retString = "";

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.White;                                                  //
            Console.Write(" Notepad   |              NET-DOS Global Edition                     |  UTF-16  ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string curLine = ReadLineOrEsc(path);
            buff.Add(curLine);

            if (File.ReadAllLines(fullPath).Length > 0)                                // НЕ ТРОГАТЬ!!!!!!!!!!!!!!!!!                                                                                                                                                                                                                                                                                                                                                                                        
            {
                string[] content = File.ReadAllLines(fullPath);
                foreach (string line in content)
                {
                    Console.WriteLine(line);
                    buff.Add(line);
                }
            }

            while (true)
            {
                int curIndex = 0;
                ConsoleKeyInfo readKeyResult = Console.ReadKey(true);

                if (readKeyResult.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(22, 7);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Do you want to save file?     Y/N");
                    ConsoleKeyInfo ynresult = Console.ReadKey(true);
                    if (ynresult.Key == ConsoleKey.N)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();
                        Console.Clear();
                        break;
                    }
                    if (ynresult.Key == ConsoleKey.Y)
                    {
                        File.WriteAllLines(path, buff.ToArray());
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Clear();
                        Console.WriteLine("File '" + path + "' has been successfly saved.\n");
                        break;
                    }
                }
                else if (readKeyResult.Key == ConsoleKey.Enter)
                {
                    Console.Write("\n");
                    buff.Add(readKeyResult.Key.ToString());
                }
                else if (readKeyResult.Key == ConsoleKey.Backspace)
                {
                    if (curIndex > 0)
                    {
                        retString = retString.Remove(retString.Length - 1);
                        Console.Write(readKeyResult.KeyChar);
                        Console.Write(' ');
                        Console.Write(readKeyResult.KeyChar);
                        curIndex--;
                    }
                }
                if (readKeyResult.Key == ConsoleKey.UpArrow)
                {
                    int top = Console.GetCursorPosition().Top;
                    top--;
                    Console.SetCursorPosition(0, top);
                }
                if (readKeyResult.Key == ConsoleKey.DownArrow)
                {
                    int top = Console.GetCursorPosition().Top; top++;
                    Console.SetCursorPosition(0, top);
                }
                if (readKeyResult.Key == ConsoleKey.LeftArrow)
                {
                    int left = Console.GetCursorPosition().Left;
                    int top = Console.GetCursorPosition().Top;
                    left--;
                    Console.SetCursorPosition(left, top);
                }
                if (readKeyResult.Key == ConsoleKey.RightArrow)
                {
                    int left = Console.GetCursorPosition().Left;
                    int top = Console.GetCursorPosition().Top;
                    left++;
                    Console.SetCursorPosition(left, top);
                }

                else
                {
                    retString += readKeyResult.KeyChar;
                    Console.Write(readKeyResult.KeyChar);
                    curIndex++;
                }
            }
        }
    }
}