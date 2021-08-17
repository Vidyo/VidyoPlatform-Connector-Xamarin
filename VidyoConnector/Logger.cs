using System;
using System.Diagnostics;

namespace VidyoConnector
{
    public class Logger
    {
        private static Logger instance = new Logger();

        public static Logger GetInstance() { return instance; }

        private Logger() {}

        public void Log(string msg)
        {
            Debug.WriteLine("VidyoConnector App: " + msg);
        }

        public void LogClientLib(string msg)
        {
            Debug.WriteLine("VidyoClientLibrary: " + msg);
        }
    }
}
