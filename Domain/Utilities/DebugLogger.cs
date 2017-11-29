using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Domain.Interfaces;

namespace Domain.Utilities
{
    public class DebugLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
