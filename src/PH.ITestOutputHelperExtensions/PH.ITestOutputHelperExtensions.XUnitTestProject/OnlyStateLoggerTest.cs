using System;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace PH.ITestOutputHelperExtensions.XUnitTestProject
{
    public class TestLoggetTest : BaseLoggerTest
    {
        public TestLoggetTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void GetALogger()
        {
            var logger      = Output.GetTestOutputLogger();
            var loggerTyped = Output.GetTestOutputLogger<OnlyStateLoggerTest>();
            var isNull      = true;
            using (var scope = loggerTyped.BeginScope("test a scope"))
            {
                isNull = scope == null;
            }

            Assert.True(logger.IsEnabled(LogLevel.Critical));
            Assert.True(loggerTyped.IsEnabled(LogLevel.Trace));
            Assert.NotNull(logger);
            Assert.NotNull(loggerTyped);
            Assert.False(isNull);

            
        }
    }

    public class OnlyStateLoggerTest : BaseLoggerTest
    {
        public OnlyStateLoggerTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void GetALogger()
        {
            var logger      = Output.GetOnlyStateLogger();
            var loggerTyped = Output.GetOnlyStateLogger<OnlyStateLoggerTest>();
            var isNull      = true;
            using (var scope = loggerTyped.BeginScope("test a scope"))
            {
                isNull = scope == null;
            }

            Assert.True(logger.IsEnabled(LogLevel.Critical));
            Assert.True(loggerTyped.IsEnabled(LogLevel.Trace));
            Assert.NotNull(logger);
            Assert.NotNull(loggerTyped);
            Assert.False(isNull);

            
        }

        
    }
}
