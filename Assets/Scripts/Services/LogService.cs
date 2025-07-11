using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class LogService : ILogger
{
    public void LogFormat(LogType logType, Object context, string format, params object[] args)
    {
    }

    public void LogException(Exception exception, Object context)
    {
    }

    public bool IsLogTypeAllowed(LogType logType)
    {
        return true;
    }

    public void Log(LogType logType, object message)
    {
    }

    public void Log(LogType logType, object message, Object context)
    {
    }

    public void Log(LogType logType, string tag, object message)
    {
    }

    public void Log(LogType logType, string tag, object message, Object context)
    {
    }

    public void Log(object message)
    {
        Debug.Log(message);
    }

    public void Log(string tag, object message)
    {
    }

    public void Log(string tag, object message, Object context)
    {
    }

    public void LogWarning(string tag, object message)
    {
    }

    public void LogWarning(string tag, object message, Object context)
    {
    }

    public void LogError(string tag, object message)
    {
    }

    public void LogError(string tag, object message, Object context)
    {
    }

    public void LogFormat(LogType logType, string format, params object[] args)
    {
    }

    public void LogException(Exception exception)
    {
    }

    public ILogHandler logHandler
    {
        get => null;
        set { }
    }

    public bool logEnabled
    {
        get => false;
        set { }
    }

    public LogType filterLogType
    {
        get => LogType.Assert;
        set { }
    }
}
