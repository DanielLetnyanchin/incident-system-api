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
            var logRecord = string.Format("Message:{0} Stack Trace:{1}", list[0],list[1]);

            logger.Debug(logRecord);
        }

        public void Error(params string[] list)
        {
            var logRecord = string.Format("Message:{0} Stack Trace:{1}", list[0], list[1]);

            logger.Error(logRecord);
        }

        public void Info(params string[] list)
        {
            var logRecord = string.Format("Message:{0} Stack Trace:{1}", list[0], list[1]);

            logger.Info(logRecord);
        }

        public void Warn(params string[] list)
        {
            var logRecord = string.Format("Message:{0} Stack Trace:{1}", list[0], list[1]);

            logger.Warn(logRecord);
        }
    }
}
