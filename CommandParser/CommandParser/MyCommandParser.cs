using System;
using System.Collections.Generic;
using System.Linq;


namespace CommandParser
{
    public class MyCommandParser
    {

        private string[] input;
        private const string helpA = "/?";
        private const string helpB = "-help";
        private const string helpC = "/help";
        private const string keyValue = "-k";
        private const string ping = "-ping";
        private const string print = "-print";
        private List<string> supportedCommands = new List<string> { helpA, helpB, helpC, keyValue, ping, print };
        private Dictionary<string, string> kCommand = new Dictionary<string, string>();
        private int loopNumber;
        private string kValue;
        private string kKey;

        public MyCommandParser(string[] Input)
        {
            input = Input;
        }

        public void Run()
        {
            while (loopNumber < input.Length)
            {
                switch (input[loopNumber])
                {

                    case ping:
                        RunPing();
                        break;

                    case keyValue:
                        RunKeyValue();
                        break;

                    case print:
                        RunPrint();
                        break;

                    case helpA:
                    case helpB:
                    case helpC:
                        RunHelp();
                        break;

                    default:
                        throw new Exception(string.Format
                            ("Command <{0}> is not supported, use " +
                             "CommandParser.exe /? to see a set of allowed commands",
                                input[loopNumber]));
                }
            }
        }

        private void RunHelp()
        {
            if (!input.Contains(keyValue) &&
                !input.Contains(ping) &&
                !input.Contains(print))
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
                loopNumber = input.Length;
            }
            loopNumber++;
        }

        private void RunPrint()
        {
            for (var i = loopNumber + 1; i < input.Length; i++)
            {
                    if (!supportedCommands.Contains(input[i]))
                    {
                        Console.Write("{0} ", input[i]);
                        loopNumber++;
                    }

                    else
                        i = input.Length;
                
            }
            Console.WriteLine();
            loopNumber++;
        }
        private void RunKeyValue()
        {
            for (var f = loopNumber + 1; f < input.Length; f++)
            {
                if (!supportedCommands.Contains(input[f]))
                {
                    kKey = input[f];
                    kValue = "<null>";
                    if (f + 1 < input.Length &&
                        !supportedCommands.Contains(input[f + 1]))
                    {
                        kValue = input[f + 1];
                        f++;
                    }
                    if (f + 1 < input.Length &&
                        supportedCommands.Contains(input[f + 1]))
                    {
                        f = input.Length;
                    }
                    kCommand.Add(kKey, kValue);
                    loopNumber++;
                }

                if (loopNumber < input.Length &&
                    !supportedCommands.Contains(input[loopNumber]))
                    loopNumber++;
            }
            foreach (var kvp in kCommand)
                Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
            if (loopNumber < input.Length &&
                !supportedCommands.Contains(input[loopNumber]))
                loopNumber++;
        }
        private void RunPing()
        {
            Console.WriteLine("Pinging...");
            Console.Beep();
            loopNumber++;
        }
    }
}