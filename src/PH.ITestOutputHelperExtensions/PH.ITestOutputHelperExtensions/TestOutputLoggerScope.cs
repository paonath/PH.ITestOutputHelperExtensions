using System;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace PH.ITestOutputHelperExtensions
{
    public class TestOutputLoggerScope<TState> : IDisposable
    {
        private readonly ILogger _output;
        private readonly TState _state;
        internal TestOutputLoggerScope(ILogger output,TState state)
        {
            _output = output;
            _state  = state;
            _output.Log(LogLevel.Debug,$"---> Begin TState {_state}");
                
            
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _output.Log(LogLevel.Debug,$"<--- Disposing TState {_state}");
            GC.SuppressFinalize(this);
        }
    }
}