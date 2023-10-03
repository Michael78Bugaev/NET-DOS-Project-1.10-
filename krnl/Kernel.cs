using Cosmos.Core.IOGroup;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Sys = Cosmos.System;
using System.ComponentModel.Design;
using netdos.techscr;

namespace netdos
{
    public class Kernel : Sys.Kernel
    {
        protected override void OnBoot()
        {
            base.OnBoot();
            Console.WriteLine("Starting NET-DOS...");
            Thread.Sleep(1000);
            welcome.Screen();
        }
        protected override void BeforeRun()
        {
            FS.initializeFs();
            BootLoader.Boot();
            
            Console.Clear();
            welcome.Screen();
            Console.WriteLine("\n");

        }

        protected override void Run()
        {
            Console.Write(FS.curPath + ">");
            terminal.execute(Console.ReadLine().Split(' ', StringSplitOptions.TrimEntries));
        }
    }
}
