using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace psKiller
{
    public static class ArgumentsParser
    {
        private static readonly double maxInterval = 35_791;
        public static (string, double, double) Parse(string[] args)
        {
            if (args.Length != 3 || args.Any(arg => string.IsNullOrWhiteSpace(arg)))
            {
                WriteErrorLine($"Expected 3 parameters 'process name', 'interval'(0 to {maxInterval} minutes) and 'timeout'(0 to {maxInterval} minutes)");
                Environment.Exit(1);
            }
            
            if (!double.TryParse(args[1], out double interval) || interval > maxInterval || interval < 0)
            {
                WriteErrorLine($"'Interval' should be within (0 to {maxInterval} minutes).");
                Environment.Exit(1);
            }

            if (!double.TryParse(args[2], out double timeout) || timeout > maxInterval || interval < 0)
            {
                WriteErrorLine($"'Timeout' should be within (0 to {maxInterval} minutes).");
                Environment.Exit(1);
            }

            var processName = args[0];
            return (processName, interval, timeout);
        }
        private static void WriteErrorLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nError: ");
            Console.ResetColor();
            Console.WriteLine(line);
        }
    }
}
