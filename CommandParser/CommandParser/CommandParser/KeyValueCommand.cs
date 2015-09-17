using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    public class KeyValueCommand : ICommand
    {
        public void Execute(string[] param)
        {
            var paramCheck = false;
            foreach (var p in param)
            {
                if (!paramCheck)
                {
                    Console.Write(p);
                    paramCheck = true;
                }
                else
                {
                    Console.WriteLine(" - {0}", p);
                    paramCheck = false;
                }
            }
            if (paramCheck)
            {
                Console.WriteLine(" - <null>");
            }
        }
    }
}
