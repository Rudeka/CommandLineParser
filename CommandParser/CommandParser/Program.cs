using System;


namespace CommandParser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                    Console.WriteLine(@"Set of supported commands:

-k key value 
shows a table of
key1 - value1
key2 - value2

-ping
makes a sound signal and print Pinging...

-print print a value
prints all text after command
");
                else
                {
                    var commandParser = new MyCommandParser(args);
                    commandParser.Run();

                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
            
        }

    }
}
