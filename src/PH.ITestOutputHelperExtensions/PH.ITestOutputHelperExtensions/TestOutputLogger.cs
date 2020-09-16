using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace PH.ITestOutputHelperExtensions
{
    public class TestOutputLogger : TestOutputOnlyStateLogger, ILogger
    {
        public TestOutputLogger(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>Writes a log entry.</summary>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a <c>string</c> message of the <paramref name="state" /> and <paramref name="exception" />.</param>
        public new void  Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string level = "";

            switch (logLevel)
            {
                case LogLevel.Trace:
                    level = "TRACE";
                    break;
                case LogLevel.Debug:
                    level = "DEBUG";
                    break;
                case LogLevel.Information:
                    level = " INFO";
                    break;
                case LogLevel.Warning:
                    level = " WARN";
                    break;
                case LogLevel.Error:
                    level = "  ERR";
                    break;
                case LogLevel.Critical:
                    level = " CRIT";
                    break;
                case LogLevel.None:
                    level = " NONE";
                    break;
            }

            var logEntry = $"{DateTime.UtcNow:O} [{level}] [{Thread.CurrentThread.ManagedThreadId}] - {state}";
            if (null != exception)
            {
                if (null != formatter)
                {
                    var sf = formatter.Invoke(state, exception);
                    logEntry += $" - {sf}";
                }
                else
                {
                    logEntry += $" - {exception.Message}";
                }

                logEntry += $" - StackTrace:\n\t {exception.StackTrace}";

            }

            Output.WriteLine(logEntry);
        }
    }

    public class TestOutputLogger<T> : TestOutputLogger, ILogger<T>
    {
        public TestOutputLogger(ITestOutputHelper output) : base(output)
        {
        }
    }
}