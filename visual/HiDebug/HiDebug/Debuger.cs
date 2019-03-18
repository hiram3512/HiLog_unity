//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System;
using UnityEngine;

public static class Debuger
{
    public static void Log(object obj)
    {
        if (HiDebug._isOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=white>" + log + "</color>";
            Debug.Log(log);
        }
    }

    public static void LogWarning(object obj)
    {
        if (HiDebug._isOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=yellow>" + log + "</color>";
            Debug.LogWarning(log);
        }
    }

    public static void LogError(object obj)
    {
        if (HiDebug._isOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=red>" + log + "</color>";
            Debug.LogError(log);
        }
    }
    private static string GetTime()
    {
        var time = DateTime.Now;
        return time.ToString("yyyy.MM.dd HH:mm:ss") + ": {0}";
    }
}