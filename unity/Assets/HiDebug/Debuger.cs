//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System;
using System.IO;
using UnityEngine;

public static class Debuger
{
    private static int _fontSize = (int)(Screen.height * 0.02f);
    public static int FontSize
    {
        get { return _fontSize; }
        set { _fontSize = value; }
    }
    private static bool _isOnConsole;
    private static bool _isOnText;
    private static bool _isOnScreen;
    private static HiDebug _instance;
    private static bool _isCallBackSet;
    public static void SetFontSize(int size)
    {
        _fontSize = size;
    }

    public static void EnableHiDebugLogs(bool isOn)
    {
        _isOnConsole = isOn;
        if (_isOnConsole)
        {
            if (!_isCallBackSet)
            {
                _isCallBackSet = true;
                Application.logMessageReceivedThreaded += LogCallBack;
            }
        }
    }

    public static void EnableOnText(bool isOn)
    {
        _isOnText = isOn;
        if (_isOnText)
        {
            EnableHiDebugLogs(true);
        }
    }

    public static void EnableOnScreen(bool isOn)
    {
        _isOnScreen = isOn;
        if (_isOnScreen)
        {
            EnableHiDebugLogs(true);
            if (_instance == null)
            {
                var go = new GameObject("HiDebug");
                UnityEngine.Object.DontDestroyOnLoad(go);
                _instance = go.AddComponent<HiDebug>();
            }
        }
    }

    public static void Log(object obj)
    {
        if (_isOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=white>" + log + "</color>";
            Debug.Log(log);
        }
    }

    public static void LogWarning(object obj)
    {
        if (_isOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=yellow>" + log + "</color>";
            Debug.LogWarning(log);
        }
    }

    public static void LogError(object obj)
    {
        if (_isOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=red>" + log + "</color>";
            Debug.LogError(log);
        }
    }

    private static void LogCallBack(string condition, string stackTrace, LogType type)
    {
        var logInfo = new LogInfo(condition, stackTrace, type);
        OnText(logInfo);
        OnScreen(logInfo);
    }
    private static string GetTime()
    {
        var time = DateTime.Now;
        return time.ToString("yyyy.MM.dd HH:mm:ss") + ": {0}";
    }

    private static void OnText(LogInfo logInfo)
    {
        if (_isOnText)
        {
            //var path = Application.persistentDataPath + "/HiDebug.txt";
            var path = Application.dataPath + "/HiDebug.txt";
            var sw = File.AppendText(path);
            sw.WriteLine(logInfo.Condition + logInfo.StackTrace);
            sw.Close();
        }
    }

    private static void OnScreen(LogInfo logInfo)
    {
        if (_isOnScreen)
        {
            _instance.UpdateLog(logInfo);
        }
    }
}