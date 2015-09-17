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
                {
                    var helpInfo = new HelpCommand();
                    var commandParser = new MyCommandParser();
                    helpInfo.Execute(args);
                    Console.WriteLine("Please enter commands: ");
                    var startArgs = Console.ReadLine().Split(' ');
                    commandParser.Run(startArgs);
                }


                else
                {
                    var commandParser = new MyCommandParser();
                    commandParser.Run(args);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }
    }
}
