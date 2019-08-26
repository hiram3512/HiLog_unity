/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * 
 * Support: hiramtan@live.com    
 *******************************************************************/

using HiLogHelper;
using UnityEngine;

public static class HiLog
{
    /// <summary>
    /// Set screen log's font size
    /// </summary>
    public static int FontSizeOnScreen = (int)(UnityEngine.Screen.width * 0.02f);

    /// <summary>
    /// Set log's foler
    /// </summary>
    public static string HiLogTextFolder = Application.persistentDataPath;

    /// <summary>
    /// Instance of view
    /// </summary>
    private static LogScreen _logScreen;

    private static LogText _logText;

    /// <summary>
    /// Set if log is on
    /// </summary>
    /// <param name="isOn"></param>
    public static void SetOn()
    {
        Debug.LogFormat("HiLog's file is here[{0}]", HiLogTextFolder);
        _logScreen = new GameObject("HiLog").AddComponent<LogScreen>();
        _logText = new LogText();
        Application.logMessageReceivedThreaded += LogCallback;
    }


    private static void LogCallback(string condition, string stackTrace, LogType type)
    {
        Text(condition, stackTrace, type);
        Screen(condition, stackTrace, type);
    }

    private static void Text(string condition, string stackTrace, LogType type)
    {
        if (_logText != null)
        {
            _logText.Text(condition, stackTrace, type);
        }
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
            _logScreen.NewLog(new LogScreenInfo(condition, stackTrace, type));
        }
    }
}
