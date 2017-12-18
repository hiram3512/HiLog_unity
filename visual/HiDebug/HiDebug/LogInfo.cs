//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using UnityEngine;

public class LogInfo
{
    public string Condition { get; private set; }
    public string StackTrace { get; private set; }
    public LogType Type { get; private set; }

    public LogInfo(string condition, string stackTrace, LogType type)
    {
        Condition = condition;
        StackTrace = stackTrace;
        Type = type;
    }
}