//****************************************************************************
// Description:hidebug's view logic
// Author: hiramtan@live.com
//****************************************************************************

using System;
using System.IO;
using UnityEditor;
using UnityEngine;
public partial class HiDebugView : MonoBehaviour
{
    private static float _buttonWidth = 0.2f;
    private static float _buttonHeight = 0.1f;
    private static float _panelHeight = 0.7f;//0.3 is for stack

    private static float _perLogHeight
    {
        get { return _fontSize / 400f; }
    }

    private static int _fontSize = (int)(Screen.height * 0.02f);
    private enum EDisplay
    {
        Button,//switch button
        Panel,//log panel
    }
    private EDisplay _eDisplay = EDisplay.Button;

    void OnGUI()
    {
        Button();
        Panel();
    }




}


public partial class HiDebugView : MonoBehaviour
{
    private enum EMouse
    {
        Up,
        Down,
    }
    private readonly float _mouseClickTime = 0.2f;//less than this is click
    private EMouse _eMouse = EMouse.Up;
    private float _mouseDownTime;
    Rect _rect = new Rect(0, 0, Screen.width * _buttonWidth, Screen.height * _buttonHeight);
    void Button()
    {
        if (_eDisplay != EDisplay.Button)
        {
            return;
        }
        if (_rect.Contains(Event.current.mousePosition))
        {
            if (Event.current.type == EventType.MouseDown)
            {
                _eMouse = EMouse.Down;
                _mouseDownTime = Time.realtimeSinceStartup;
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                _eMouse = EMouse.Up;
                if (Time.realtimeSinceStartup - _mouseDownTime < _mouseClickTime)//click
                { _eDisplay = EDisplay.Panel; }
            }
        }
        if (_eMouse == EMouse.Down && Event.current.type == EventType.mouseDrag)
        {
            _rect.x = Event.current.mousePosition.x - _rect.width / 2f;
            _rect.y = Event.current.mousePosition.y - _rect.height / 2f;
        }
        GUI.Button(_rect, "On", GetGUISkin(GUI.skin.button, Color.white));
    }
}

public partial class HiDebugView : MonoBehaviour
{
    private bool _isLogOn = true;
    private bool _isWarnningOn = true;
    private bool _isErrorOn = true;

    void Panel()
    {
        if (_eDisplay != EDisplay.Panel)
            return;

        GUI.Window(0, new Rect(0, 0, Screen.width, Screen.height * _panelHeight), LogWindow, "HiDebug", GetGUISkin(GUI.skin.window, Color.white));
        GUI.Window(1, new Rect(0, Screen.height * _panelHeight, Screen.width, Screen.height * (1 - _panelHeight)), StackWindow, "Stack", GetGUISkin(GUI.skin.window, Color.white));
    }
    private Vector2 _scrollLogPosition;
    void LogWindow(int windowID)
    {
        if (GUI.Button(new Rect(0, 0, Screen.width * _buttonWidth, Screen.height * _buttonHeight), "Clear", GetGUISkin(GUI.skin.button, Color.white)))
        {
            Debug.Log(Screen.height * _perLogHeight);
            _scrollLogPosition = new Vector2(0, Screen.height * _perLogHeight * 20);
        }
        if (GUI.Button(new Rect(Screen.width * (1 - _buttonWidth), 0, Screen.width * _buttonWidth, Screen.height * _buttonHeight), "Close", GetGUISkin(GUI.skin.button, Color.white)))
        {
            _eDisplay = EDisplay.Button;
        }
        var headHeight = GUI.skin.window.padding.top;//height of head
        var logStyle = GetGUISkin(new GUIStyle(GUI.skin.toggle), Color.white);
        _isLogOn = GUI.Toggle(new Rect(Screen.width * 0.3f, headHeight, Screen.width * _buttonWidth, Screen.height * _buttonHeight - headHeight), _isLogOn, "Log", logStyle);
        var WarnningStyle = GetGUISkin(new GUIStyle(GUI.skin.toggle), Color.yellow);
        _isWarnningOn = GUI.Toggle(new Rect(Screen.width * 0.5f, headHeight, Screen.width * _buttonWidth, Screen.height * _buttonHeight - headHeight), _isWarnningOn, "Warnning", WarnningStyle);
        var errorStyle = GetGUISkin(new GUIStyle(GUI.skin.toggle), Color.red);
        _isErrorOn = GUI.Toggle(new Rect(Screen.width * 0.7f, headHeight, Screen.width * _buttonWidth, Screen.height * _buttonHeight - headHeight), _isErrorOn, "Error", errorStyle);

        GUILayout.Space(Screen.height * _buttonHeight - headHeight);
        _scrollLogPosition = GUILayout.BeginScrollView(_scrollLogPosition);
        Debug.LogError(_scrollLogPosition);
        TestButton();
        GUILayout.EndScrollView();
    }

    void TestButton()
    {
        for (int i = 0; i < 20; i++)
        {
            GUILayout.Button("lsafjdlsjfdjskaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaas", GetGUISkin(GUI.skin.button, Color.white), GUILayout.Height(Screen.height * _perLogHeight));

        }
    }




    private Vector2 _scrollStackPosition;
    void StackWindow(int windowID)
    {
        _scrollStackPosition = GUILayout.BeginScrollView(_scrollStackPosition);
        TestButton();
        GUILayout.EndScrollView();
    }

    GUIStyle GetGUISkin(GUIStyle guiStyle, Color color)
    {
        guiStyle.normal.textColor = color;
        guiStyle.hover.textColor = color;
        guiStyle.active.textColor = color;
        guiStyle.onNormal.textColor = color;
        guiStyle.onHover.textColor = color;
        guiStyle.onActive.textColor = color;
        guiStyle.margin = new RectOffset(0, 0, 0, 0);
        guiStyle.fontSize = _fontSize;
        return guiStyle;
    }
}
//runtime
public class Debuger_Hi : MonoBehaviour
{
    private static bool _isOnConsole;
    private static bool _isOnText;
    private static bool _isOnScreen;
    private static HiDebugView _instance;
    private static bool _isCallBackSet;
    public static void SetFontSize()
    {

    }

    public static void EnableOnConsole(bool isOn)
    {
        _isOnConsole = isOn;
        if (!_isCallBackSet)
        {
            _isCallBackSet = true;
            Application.logMessageReceivedThreaded += LogCallBack;
        }
    }

    public static void EnableOnText(bool isOn)
    {
        _isOnText = isOn;
        if (_isOnText)
            EnableOnConsole(true);
    }

    public static void EnableOnScreen(bool isOn)
    {
        _isOnScreen = isOn;
        if (_isOnScreen)
        {
            EnableOnConsole(true);
            if (_instance == null)
            {
                var go = new GameObject("HiDebug");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<HiDebugView>();
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
        OnText(condition);
    }
    private static string GetTime()
    {
        var time = DateTime.Now;
        return time.ToString("yyyy.MM.dd HH:mm:ss") + ": {0}";
    }

    private static void OnText(string log)
    {
        if (_isOnText)
        {
            var path = Application.persistentDataPath + "/HiDebug.txt";
            var sw = File.AppendText(path);
            sw.WriteLine(log);
            sw.Close();
        }
    }

    private static void OnScreen(string condition, string stackTrace, LogType type)
    {
        if (_isOnScreen)
        {

        }
    }
}