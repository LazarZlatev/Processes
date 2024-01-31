internal class Logger
{
    public static void LogInfo(string message)
    {
        var desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var logMessage = $"{DateTime.Now}: {message}";

        // Log to the console
        Console.WriteLine(logMessage);

        // Log to the file
        using StreamWriter sw = File.AppendText(Path.Combine(desktopFolderPath,"Log.txt"));
        sw.WriteLine(logMessage);
    }
}