using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netdos
{
    public class Logger
    {
        public string pathtologfile;

        public Logger(string path) { pathtologfile = path; }
        public void Write(string text)
        {
            if (pathtologfile != null)
            {
                StreamWriter writer = new StreamWriter(pathtologfile, true);
                writer.Write(text);
                writer.Close();
            }
            else
            {
                Console.WriteLine("Path to log file is empty!");
            }
        }
        public void writeLine(string text)
        {
            if (pathtologfile!= null)
            {
                StreamWriter writer = new StreamWriter(pathtologfile, true);
                writer.WriteLine(text);
                writer.Close();
            }
            else
            {
                Console.WriteLine("Path to log file is empty!");
            }
        }
    }
}
