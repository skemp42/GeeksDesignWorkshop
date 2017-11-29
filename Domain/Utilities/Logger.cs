using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Domain.Interfaces;

namespace Domain.Utilities
{
    public static class Logger
    {
        private static List<ILogger> Loggers { get; set; } = new List<ILogger>();

        public static void Log(string message)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(message);
            }
        }

        public static void RegisterLogger(ILogger logger)
        {
            Loggers.Add(logger);
        }
    }
}
