using Microsoft.Extensions.Logging;

namespace Store.BussinesLogic.Common
{
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        private string _filePath;

        public ApplicationLoggerProvider(string filePath)
        {
            _filePath = filePath;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new ApplicationLogger(_filePath);
        }

        public void Dispose()
        {
        }
    }
}
