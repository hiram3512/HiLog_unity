using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public sealed class MyDebug : MonoBehaviour
{
    public static int itemCountOnScreen = 100;//拖拽区域包含多少条log信息
    private static bool isLogOnScreen = false;
    private static bool isLogOnConsole = false;
    private static bool isLogOnText = false;
    private static List<string> logOnScreenList = new List<string>();
    private static string logOnScreen;
    private static Vector2 scrollPosition;
    private MyDebug() { }
    public static void EnabelOnConsole(bool _isLogOnConsole)
    {
        isLogOnConsole = _isLogOnConsole;
    }
    public static void EnabelOnScreen(bool _isLogOnScreen)
    {
        isLogOnConsole = isLogOnScreen = _isLogOnScreen;
        new GameObject("MyDebug").AddComponent<MyDebug>();
        Application.logMessageReceived += (string _log, string _stackTrace, LogType _type) =>
        {
            UpdateScrollPosition();
        };
        Application.logMessageReceivedThreaded += (string _log, string _stackTrace, LogType _type) =>
         {
             UpdateScrollPosition();
         };
    }
    public static void EnabelOnText(bool param)
    {
        isLogOnConsole = isLogOnText = param;
    }
    public static void Log(object _obj)
    {
        if (isLogOnConsole)
        {
            string log = string.Format(GetTime(), "Log", _obj.ToString());
            Debug.Log(log);
            if (isLogOnScreen)
                OnScreen(log);
            if (isLogOnText)
                WriteLog(log);
        }
    }
    public static void LogWarning(object _obj)
    {
        if (isLogOnConsole)
        {
            string log = string.Format(GetTime(), "Warning", _obj.ToString());
            Debug.LogWarning(log);
            if (isLogOnScreen)
                OnScreen(log);
            if (isLogOnText)
                WriteLog(log);
        }
    }
    public static void LogError(object _obj)
    {
        if (isLogOnConsole)
        {
            string log = string.Format(GetTime(), "Error", _obj.ToString());
            Debug.LogError(log);
            if (isLogOnScreen)
                OnScreen(log);
            if (isLogOnText)
                WriteLog(log);
        }
    }
    void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height));
        GUILayout.Label(logOnScreen);
        GUILayout.EndScrollView();
    }
    static void UpdateScrollPosition()
    {
        scrollPosition = new Vector2(scrollPosition.x, scrollPosition.y + logOnScreenList.Count);
    }
    private static void OnScreen(string _log)
    {
        logOnScreenList.Add(_log);
        if (logOnScreenList.Count > itemCountOnScreen)
            logOnScreenList.RemoveAt(0);
        logOnScreen = string.Empty;
        foreach (string _s in logOnScreenList)
            logOnScreen = string.IsNullOrEmpty(logOnScreen) ? logOnScreen = _s : logOnScreen = logOnScreen + "\n" + _s;//第一行不用换行
    }
    private static string GetTime()
    {
        DateTime time = DateTime.Now;
        return time.ToString("yyyy.MM.dd HH:mm:ss") + "[{0}]: {1}";
    }
    private static void WriteLog(string param)
    {
        string path = Application.persistentDataPath + "/MyDebug.txt";
        StreamWriter sw = File.AppendText(path);
        sw.WriteLine(param);
        sw.Close();
    }
}