using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Store.BusinessLogic.Common
{
    public class ApplicationLogger : ILogger
    {
        private object _lock = new object();
        private string _filePath;

        public ApplicationLogger(string filePath)
        {
            _filePath = filePath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(_filePath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
