/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using System;
using System.IO;
using UnityLogHelper;
using UnityEngine;

public static class HiLog
{
    /// <summary>
    /// Instance of view
    /// </summary>
    private static LogScreen _logScreen;

    /// <summary>
    /// Set screen log's font size
    /// </summary>
    public static int FontSizeOnScreen = (int)(UnityEngine.Screen.width * 0.02f);

    public static string HiLogTextPath = Application.persistentDataPath + "/HiLog.txt";

    /// <summary>
    /// Set if log is on
    /// </summary>
    /// <param name="isOn"></param>
    public static void SetOn(bool isOn)
    {
        if (isOn)
        {
            Debug.Log(string.Format("HiLog's file is here[{0}]", Application.persistentDataPath));
            _logScreen = new GameObject("HiLog").AddComponent<LogScreen>();
            Application.logMessageReceivedThreaded += LogCallback;
        }
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
        var sw = File.AppendText(HiLogTextPath);
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
        if (_logScreen != null)
        {
            var timeInfo = string.Format("[{0}]", GetTime());
            _logScreen.NewLog(new LogScreenInfo(timeInfo + condition, stackTrace, type));
        }
    }
}
