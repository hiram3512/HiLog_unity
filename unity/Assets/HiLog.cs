using System;
using System.IO;
using UnityLogHelper;
using UnityEngine;

public static class HiLog
{
    /// <summary>
    /// Instance of view
    /// </summary>
    private static LogView _logView;

    /// <summary>
    /// Set screen log's font size
    /// </summary>
    public static int FontSizeOnScreen = (int)(UnityEngine.Screen.width * 0.02f);

    /// <summary>
    /// Set if log is on
    /// </summary>
    /// <param name="isOn"></param>
    public static void SetOn(bool isOn)
    {
        _logView = new GameObject("HiLog").AddComponent<LogView>();
        Application.logMessageReceivedThreaded += LogCallback;
    }


    private static void LogCallback(string condition, string stackTrace, LogType type)
    {
        Text(condition, stackTrace, type);
        Screen(condition, stackTrace, type);
    }

    private static string GetTime()
    {
        var time = DateTime.Now;
        return time.ToString("yyyy.MM.dd HH:mm:ss");
    }

    /// <summary>
    /// Write log in text
    /// For editor path is dataPath, and for other platform path is persistentDataPath
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="stackTrace"></param>
    /// <param name="type"></param>
    private static void Text(string condition, string stackTrace, LogType type)
    {
        var typeInfo = string.Format("[{0}]", type.ToString());
        var timeInfo = string.Format("[{0}]", GetTime());
        var log = typeInfo + timeInfo + condition;
#if UNITY_EDITOR
        var path = Application.dataPath + "/HiLog.txt";
#else
            var path = Application.persistentDataPath + "/HiLog.txt";
#endif
        var sw = File.AppendText(path);
        sw.WriteLine(log + "\n" + stackTrace);
        sw.Close();
    }

    /// <summary>
    /// Display log on Screen
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="stackTrace"></param>
    /// <param name="type"></param>
    private static void Screen(string condition, string stackTrace, LogType type)
    {
        if (_logView != null)
        {
            var timeInfo = string.Format("[{0}]", GetTime());
            _logView.NewLog(new LogInfo(timeInfo + condition, stackTrace, type));
        }
    }
}
