using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    public class ExitCommand : ICommand
    {
        public void Execute(string[] param)
        {
            Environment.Exit(0);
        }
    }
}
