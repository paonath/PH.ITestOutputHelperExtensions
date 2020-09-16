using Xunit.Abstractions;

namespace PH.ITestOutputHelperExtensions.XUnitTestProject
{
    public abstract class BaseLoggerTest
    {
        protected ITestOutputHelper Output;

        protected BaseLoggerTest(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}