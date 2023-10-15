using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace netdos.Network
{
    internal class lib
    {
        public static void Update()
        {
            if (!File.Exists(@"0:\SYS\Params\update.o"))
            {
                File.Create(@"0:\SYS\Params\update.o");
                File.WriteAllText(@"0:\SYS\Params\update.o", "update = true");
                
            }
        }
    }
}
