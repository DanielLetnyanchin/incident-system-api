using IncidentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
//using NLog;

namespace IncidentSystem.Common
{
    public class LoggerWrapper : ILoggerWrapper
    {
        //private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerWrapper()
        {
        }

        public void Debug(params string[] list)
        {
            //logger.Debug(srting mesage, string stackTrace, string ImportantString);
        }

        public void Error(params string[] list)
        {
            //logger.Error(srting mesage, string stackTrace, string ImportantString);
        }

        public void Info(params string[] list)
        {
            //logger.Info(srting mesage, string stackTrace, string ImportantString);
        }

        public void Warn(params string[] list)
        {
            //logger.Warn(srting mesage, string stackTrace, string ImportantString);
        }
    }
}
