using Processes.Application;


class ProcessMonitor
{
    static string? processName;
    static int maxLifetimeSeconds;
    static int monitorFrequencySeconds;
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Process name: "); // e.g. : wordpad, notepad
        processName = Console.ReadLine();
        Console.WriteLine("Enter Process Life time in seconds: ");
        maxLifetimeSeconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Process check Frequency in seconds: ");
        monitorFrequencySeconds = int.Parse(Console.ReadLine());

        Logger.LogInfo($"Monitoring process: {processName}, Max Lifetime: {maxLifetimeSeconds} seconds, Frequency: {monitorFrequencySeconds} seconds");

        Logger.LogInfo("Press 'q' to quit.");

        try
        {
            while (true)
            {
                Programm.KillProcessesIfExceedLifetime(processName, maxLifetimeSeconds);
                Thread.Sleep(monitorFrequencySeconds * 1000);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Q)
                    {
                        Logger.LogInfo("Exiting the program.");
                        Environment.Exit(0);
                    }
                }
            }
        }

        catch (ApplicationException ex)
        {
            Logger.LogInfo($"{ex.Message}");
        }
    }
}
