using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class PrintCommand : ICommand
    {
        public void Execute(string[] param)
            {
                foreach (var p in param)
                {
                    Console.Write(p);
                }
                Console.WriteLine();
            }
    }
}
