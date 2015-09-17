using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    public class HelpCommand : ICommand
    {
        public void Execute(string[] param)
        {
            Console.WriteLine(@"Set of supported commands:

-k key value 
shows a table of
key1 - value1
key2 - value2

-ping
makes a sound signal and print Pinging...

-print print a value
prints all text after command

-exit
exit the application
");
        }
    }
}
