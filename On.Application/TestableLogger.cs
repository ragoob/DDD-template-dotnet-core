using Microsoft.Extensions.Logging;
using On.Core;

namespace On.Application
{
    public class TestableLogger : ILoggingService
    {
        private readonly ILogger<TestableLogger> _logger;

        public TestableLogger(ILogger<TestableLogger> logger)
        {
            _logger = logger;
        }
        public void LogInformation(string message, params object[] parameters)
        {
            _logger.LogInformation(message,parameters);
        }
    }
}
