using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentSystem.Interfaces
{
    public interface ILoggerWrapper
    {
        void Info(params string[] list);
        void Warn(params string[] list);
        void Debug(params string[] list);
        void Error(params string[] list);
    }
}
