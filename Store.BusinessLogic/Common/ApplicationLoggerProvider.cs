using Microsoft.Extensions.Logging;
using System;

namespace Store.BusinessLogic.Common
{
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        private readonly string _filePath;
        private ILogger _logger;

        public ApplicationLoggerProvider(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("filePath is required", "filePath");

            _filePath = filePath;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _logger ?? (_logger = new ApplicationLogger(_filePath));
        }

        public void Dispose()
        {
        }
    }
}
