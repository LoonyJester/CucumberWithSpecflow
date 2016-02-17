using System;

namespace Definitions
{
    public interface ILogger
    {
        void Error(Exception e, string message);
        void Info(string message);
        void Warning(string message);
        void Warning(Exception e);
    }
}