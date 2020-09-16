using System;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace PH.ITestOutputHelperExtensions
{
    /// <summary>
    /// Write log entries (only state: just for simply output on test methods)
    /// </summary>
    public class TestOutputOnlyStateLogger : AbsTestOutputLogger , ILogger
    {
        public TestOutputOnlyStateLogger(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>Writes a log entry.</summary>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a <c>string</c> message of the <paramref name="state" /> and <paramref name="exception" />.</param>
        public override void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Output.WriteLine($"{state}");
        }
    }

    /// <summary>
    /// Write log entries (only state: just for simply output on test methods)
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <seealso cref="PH.ITestOutputHelperExtensions.AbsTestOutputLogger" />
    /// <seealso cref="Microsoft.Extensions.Logging.ILogger" />
    public class TestOutputOnlyStateLogger<TService> : TestOutputOnlyStateLogger, ILogger<TService>
    {
        public TestOutputOnlyStateLogger(ITestOutputHelper output) : base(output)
        {
        }
    }

    
}