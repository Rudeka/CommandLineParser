using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;


namespace CommandParser
{
    public interface ICommand
    {
        void Execute(string[] param);
    }

    public class PingCommand : ICommand
    {
        public void Execute(string[] param)
        {
            Console.WriteLine("Pinging...");
            Console.Beep();
        }
    }

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

    public class PrintCommand : ICommand
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
");
        }
    }

    public class ExitCommand : ICommand
    {
        public void Execute(string[] param)
        {
            Environment.Exit(0);
        }
    }

    public static class ArgumentsForCommands
    {
        public static string[] argumentsForCommands(string[] param,
            Dictionary<string, ICommand> supportedCommands, int loopNumber)
        {
            var listOfParams = new List<string>();
            for (int i = loopNumber + 1; i < param.Length; i++)
            {
                if (supportedCommands.ContainsKey(param[i]))
                {
                    break;
                }
                else
                {
                    listOfParams.Add(param[i]);
                }
            }
            return listOfParams.ToArray();
        }
    }

    public class MyCommandParser
    {
        private string[] input;
        private Dictionary<string, ICommand> Commands = 
            new Dictionary<string, ICommand>();
        
        public MyCommandParser(string[] Input)
        {
            input = Input;
            Commands.Add("-print", new PrintCommand());
            Commands.Add("-k", new KeyValueCommand());
            Commands.Add("-ping", new PingCommand());
            Commands.Add("-help", new HelpCommand());
            Commands.Add("/help", new HelpCommand());
            Commands.Add("/?", new HelpCommand());
            Commands.Add("-exit", new ExitCommand());
        }

        public void Run()
        {
            for (int i = 0; i < input.Length; i++)
            {
                ICommand command;
                if (Commands.TryGetValue(input[i], out command))
                {
                    command.Execute(ArgumentsForCommands.
                        argumentsForCommands(input, Commands, i));
                }
            }
            AddParams();
        }

        public void AddParams()
        {
            string newLine = Console.ReadLine();
            if (!String.IsNullOrEmpty(newLine))
            {
                input = newLine.Split(new char[] {' '});
                Run();
            }
        }
    }
}

        