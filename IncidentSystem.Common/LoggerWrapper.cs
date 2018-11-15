using IncidentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using NLog;


namespace IncidentSystem.Common
{
    public class LoggerWrapper : ILoggerWrapper
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerWrapper()
        {
        }

        public void Debug(params string[] list)
        {
            var logRecord = string.Format("RequestId: {0};  Message: {1};  Stack Trace:{2}", list[0], list[1], list[2]);

            logger.Debug(logRecord);
        }

        public void Error(params string[] list)
        {
            var logRecord = string.Format("RequestId: {0};  Message: {1};  Stack Trace:{2}", list[0], list[1], list[2]);

            logger.Error(logRecord);
        }

        public void Info(params string[] list)
        {
            var logRecord = string.Format("RequestId: {0};  Message: {1};  Stack Trace:{2}", list[0], list[1], list[2]);

            logger.Info(logRecord);
        }

        public void Warn(params string[] list)
        {
            var logRecord = string.Format("RequestId: {0};  Message: {1};  Stack Trace:{2}", list[0], list[1], list[2]);

            logger.Warn(logRecord);
        }
    }
}
