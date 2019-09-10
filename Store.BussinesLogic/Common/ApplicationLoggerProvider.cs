using Microsoft.Extensions.Logging;
using System;

namespace Store.BussinesLogic.Common
{
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        private string _filePath;
        private ILogger _logger;

        public ApplicationLoggerProvider(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("filePath is required", "filePath");

            _filePath = filePath;
        }
        public ILogger CreateLogger(string categoryName)
        {
            if (_logger == null)
                _logger = new ApplicationLogger(_filePath);
            return _logger;
        }

        public void Dispose()
        {
        }
    }
}
