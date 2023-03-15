using System.Diagnostics;
using System.IO;
using System.Timers;

namespace psKiller
{
    public sealed class ProcessesHandler
    {
        private readonly string _processName;
        private readonly TimeSpan _timeout;

        public ProcessesHandler(string processName, double timeout)
        {
            _timeout= TimeSpan.FromMinutes(timeout);
            _processName= processName;
        }

        public void SearchAndKill(object? sender, ElapsedEventArgs e)
        {
            Process[] runningProcesses = Process.GetProcessesByName(_processName);
            foreach (Process process in runningProcesses)
            {
                TimeSpan elapsedTime = DateTime.Now - process.StartTime;
                if (elapsedTime > _timeout)
                {
                    string message = $"\n{DateTime.Now} - Killing process: {process.ProcessName} Id:{process.Id} Run for: {elapsedTime.TotalMinutes} minutes";
                    File.AppendAllText("psKiller-Log.txt", message);
                    Console.WriteLine(message);

                    process.Kill(true);
                    process.WaitForExit();
                }
            }
        }
    }
}
