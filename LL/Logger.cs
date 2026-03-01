using System;
using System.IO;

namespace LL
{
    public class Logger
    {
        private static string _LogFilePath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Logs", 
                    "AppLog.txt");
            }
        }
        static Logger()
        {
            string Folder = Path.GetDirectoryName(_LogFilePath);
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
            if(File.Exists(_LogFilePath) &&
                new FileInfo(_LogFilePath).Length > 5_000_000)
            {
                File.Delete(_LogFilePath);
            }
        }
        private enum _enLogBehavior
        {
            ERROR,
            INFO,
            WARNING
        }
        private static _enLogBehavior _LogBehavior;
        private static void _Log(StreamWriter Writer, _enLogBehavior bahavior,
            string message)
        {
            Writer.WriteLine("_____" + bahavior.ToString() + "_____");
            Writer.WriteLine("Date & Time: {0};", DateTime.Now.ToString("g"));
            Writer.WriteLine("Message: {0};", message);
        }
        private static void _GeneralLog(string message,_enLogBehavior Behavior, 
            Exception ex = null)
        {
            try
            {
                using (StreamWriter Writer = new StreamWriter(_LogFilePath, true))
                {
                    _Log(Writer, _LogBehavior, message);
                    if (ex != null)
                    {
                        Writer.WriteLine("Exception: {0};", ex.Message);
                        Writer.WriteLine("Stack Trace: {0};", ex.StackTrace);
                    }
                }
            }
            catch
            {
                //If logging fails, we silently ignore to avoid crashing the application
            }
        }
        public static void LogError(string message, Exception ex)
        {
            _LogBehavior = _enLogBehavior.ERROR;
            _GeneralLog(message, _LogBehavior, ex);
        }
        public static void LogInfo(string message)
        {
            _LogBehavior = _enLogBehavior.INFO;
            _GeneralLog(message, _LogBehavior);
        }
        public static void LogWarning(string message)
        {
            _LogBehavior = _enLogBehavior.WARNING;
            _GeneralLog(message, _LogBehavior);
        }
    }
}
