using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Services
{
    public class LoggerService : ILogger
    {
        private readonly string filePath;
        private readonly string _category;
        private readonly static object _lock = new object();
        public LoggerService(string category, string path)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), path);
            _category = category;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if ((int)logLevel >= 1)
                return true;
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null && IsEnabled(logLevel))
            {
                lock (_lock)
                {
                    File.AppendAllText(filePath, $"{logLevel.ToString()}: {_category}[{eventId.Id}] \r\n    " + formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
    public class FileLoggerProvider : ILoggerProvider
    {
        private string path;
        public FileLoggerProvider(string _path)
        {
            path = _path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new LoggerService(categoryName, path);
        }

        public void Dispose()
        {
        }
    }
}
