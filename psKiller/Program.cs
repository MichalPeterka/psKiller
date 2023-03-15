using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace psKiller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (processName, interval, timeout) = ArgumentsParser.Parse(args);
            ProcessesHandler ProcessesHandler = new(processName, timeout);

            Console.WriteLine($"Monitoring: {processName} Interval: {interval} minutes Max running time: { timeout} minutes");

            var timer = new System.Timers.Timer(interval * 60 * 1000);
            timer.Elapsed += ProcessesHandler.SearchAndKill;
            timer.Start();

            ConsoleKeyInfo lastPressedKey;
            do
            {
                Console.WriteLine("Press 'q' to stop");
                lastPressedKey = Console.ReadKey();
            } while (lastPressedKey.Key != ConsoleKey.Q);

            Console.WriteLine("\nYou pressed 'q' key. Ending the psKiller.");
        }
    }
}