using System;
using UnityEngine;

namespace MRI.Neural.Log
{
    public class Unity3dLogger : ILogger
    {
        public void Log(LogEntry entry)
        {
            string message = entry.Message;
            if (entry.Exception != null)
            {
                message += "\nWith Exception: " + entry.Exception.Message + "\n" + entry.Exception.StackTrace;
            }

            switch (entry.Severity)
            {
                case LoggingEventType.Debug:
                    Debug.Log("DEBUG: " + message);
                    break;
                case LoggingEventType.Information:
                    Debug.Log(message);
                    break;
                case LoggingEventType.Warning:
                    Debug.LogWarning(message);
                    break;
                case LoggingEventType.Error:
                    Debug.LogError(message);
                    break;
                case LoggingEventType.Fatal:
                    Debug.LogError("FATAL: " + message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}