using Cosmos.Core.IOGroup;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Sys = Cosmos.System;
using System.ComponentModel.Design;
using netdos.Graphic;
using netdos.Network.Configure;

namespace netdos
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            FS.initializeFs();
            BootLoader.Boot();
            NetworkConfiguration.Configure();
            
            TaskBar.Show(0);

        }

        protected override void Run()
        {
            Console.Write(FS.curPath + ">");
            terminal.execute(Console.ReadLine().Split(' ', StringSplitOptions.TrimEntries));
        }
    }
}
