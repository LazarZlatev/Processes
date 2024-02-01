using System.Diagnostics;

namespace Processes.Application
{
    public class Programm
    {
        public static void KillProcessesExceedingLifeTime(string processName, int maxLifetimeMinutes)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                TimeSpan processLifetime = DateTime.Now - process.StartTime;

                if (processLifetime.TotalSeconds > maxLifetimeMinutes)
                {
                    Logger.LogInfo($"Killing process {process.ProcessName} (ID: {process.Id}) with lifetime {processLifetime.TotalSeconds} seconds");
                    
                    process.Kill();
                }
            }   
        }
    }
}
