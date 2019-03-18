/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////

using System.IO;
using UnityEngine;
public class HiDebug
{
    private static int _fontSize = (int)(Screen.height * 0.02f);
    public static int FontSize
    {
        get { return _fontSize; }
        set { _fontSize = value; }
    }
    private static HiDebugView _instance;
    internal static bool _isOnConsole;
    internal static bool _isOnText;
    internal static bool _isOnScreen;
    private static bool _isCallBackSet;
    public static void SetFontSize(int size)
    {
        _fontSize = size;
    }

    /// <summary>
    /// 启动HiDebug日志:附加时间,一键关闭等
    /// </summary>
    /// <param name="isOn"></param>
    public static void EnableDebuger(bool isOn)
    {
        _isOnConsole = isOn;
    }
    public static void EnableOnText(bool isOn)
    {
        _isOnText = isOn;
        if (_isOnText)
        {
            EnableCallBack();
        }
    }

    public static void EnableOnScreen(bool isOn)
    {
        _isOnScreen = isOn;
        if (_isOnScreen)
        {
            if (_instance == null)
            {
                var go = new GameObject("HiDebug");
                _instance = go.AddComponent<HiDebugView>();
                UnityEngine.Object.DontDestroyOnLoad(go);
            }
            EnableCallBack();
        }
    }
    private static void EnableCallBack()
    {
        if (!_isCallBackSet)
        {
            _isCallBackSet = true;
            Application.logMessageReceivedThreaded += LogCallBack;
        }
    }
    private static void LogCallBack(string condition, string stackTrace, LogType type)
    {
        var logInfo = new LogInfo(condition, stackTrace, type);
        OnText(logInfo);
        OnScreen(logInfo);
    }
    private static void OnText(LogInfo logInfo)
    {
        if (_isOnText)
        {
            var path = Application.persistentDataPath + "/HiDebug.txt";
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