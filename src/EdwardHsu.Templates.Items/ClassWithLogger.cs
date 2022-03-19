using Microsoft.Extensions.Logging;

namespace EdwardHsu.Templates.Items
{
    public class ClassWithLogger
    {
        private readonly ILogger _logger;

        public ClassWithLogger(ILogger<ClassWithLogger> logger)
        {
            _logger = logger;
        }
    }
}