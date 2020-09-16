using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace PH.ITestOutputHelperExtensions
{
    public static class TestOutputHelperExtensions
    {
        /// <summary>
        /// Get a Ilogger thats log only state param.
        /// </summary>
        /// <param name="testOutputHelper"></param>
        /// <returns></returns>
        [NotNull]
        public static ILogger GetOnlyStateLogger(this ITestOutputHelper testOutputHelper)
        {
            return new TestOutputOnlyStateLogger(testOutputHelper);
        }

        /// <summary>
        /// Get a Ilogger thats log only state param.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="testOutputHelper"></param>
        /// <returns></returns>
        [NotNull]
        public static ILogger<T> GetOnlyStateLogger<T>(this ITestOutputHelper testOutputHelper)
        {
            return new TestOutputOnlyStateLogger<T>(testOutputHelper);
        }

        /// <summary>Gets the test output logger.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        /// <returns></returns>
        [NotNull]
        public static ILogger GetTestOutputLogger(this ITestOutputHelper testOutputHelper)
        {
            return new TestOutputLogger(testOutputHelper);
        }

        [NotNull]
        public static ILogger<T> GetTestOutputLogger<T>(this ITestOutputHelper testOutputHelper)
        {
            return new TestOutputLogger<T>(testOutputHelper);
        }
    }
}
