using System;
using System.IO;

namespace Notes
{
    public static class Logger
    {
        private static string logFile = "log.txt";

        public static void Log(string message)
        {
            try
            {
                File.AppendAllText(logFile, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}");
            }
            catch { }
        }
    }
}
