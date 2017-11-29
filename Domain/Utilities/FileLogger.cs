using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain.Interfaces;

namespace Domain.Utilities
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("../Data/log.txt", message + Environment.NewLine);
        }
    }
}
