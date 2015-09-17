using System.Collections.Generic;


namespace CommandParser
{
    public static class ArgumentsForCommands
    {
        public static bool IsCommand(this string command)
        {
            return command.StartsWith("-") || command.StartsWith("/");
        }

        public static string[] argumentsForCommands(string[] param, int loopNumber)
        {
            var listOfParams = new List<string>();
            for (int i = loopNumber + 1; i < param.Length; i++)
            {
                var currentParam = param[i];

                if (currentParam.IsCommand())
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
}
