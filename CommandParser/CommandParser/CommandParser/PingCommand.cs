using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    public class PingCommand : ICommand
    {
        public void Execute(string[] param)
        {
            Console.WriteLine("Pinging...");
            Console.Beep();
        }
    }
}
