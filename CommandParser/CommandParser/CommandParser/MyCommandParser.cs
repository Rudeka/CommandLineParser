using System;
using System.Collections.Generic;

namespace CommandParser
{
    public class MyCommandParser
    {
        private Dictionary<string, ICommand> Commands;

        public MyCommandParser()
        {
            Commands = new Dictionary<string, ICommand>();
            Commands.Add("-print", new PrintCommand());
            Commands.Add("-k", new KeyValueCommand());
            Commands.Add("-ping", new PingCommand());
            Commands.Add("-help", new HelpCommand());
            Commands.Add("/help", new HelpCommand());
            Commands.Add("/?", new HelpCommand());
            Commands.Add("-exit", new ExitCommand());
        }

        public void Run(string[] startParams)
        {
            var input = startParams;
            while (true)
            {
                ExecuteParams(input);
                Console.WriteLine("Please enter commands: ");
                input = Console.ReadLine().Split(' ');
            };
        }

        private void ExecuteParams(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var currentInput = input[i];
                if (currentInput.IsCommand())
                {
                    ICommand command;
                    if (Commands.TryGetValue(currentInput.ToLower(), out command))
                    {
                        var comandParams = ArgumentsForCommands.argumentsForCommands(input, i);
                        command.Execute(comandParams);
                    }
                    else
                    {
                        Console.WriteLine("Command {0} is not supported, use CommandParser.exe /? to see set of allowed commands", currentInput);
                    }
                }
            }
        }
    }
}
