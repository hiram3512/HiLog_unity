//****************************************************************************
// Description:hidebug's view logic
// Author: hiramtan@live.com
//****************************************************************************

#define HiDebug_CurrentMouse

using UnityEngine;
public partial class HiDebugView : MonoBehaviour
{
    private static float _buttonWidth = 0.2f;
    private static float _buttonHeight = 0.1f;
    private static float _panelHeight = 0.2f;//0.3 is for stack
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

        //else if (_eState == EDisplay.Panel)
        //{

        //    _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height * 0.8f));
        //    var tempGuiStyle = new GUIStyle();
        //    //tempGuiStyle.fontSize = FontSize;
        //    GUILayout.Label("helfgdjklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklklkl" +
        //                    "dsfalllllllllllllllllllllllllllkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkjkj" +
        //                    "dfsaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaljlo", tempGuiStyle);
        //    GUILayout.EndScrollView();
        //}
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
            Debug.LogError("drag");
            _rect.x = Event.current.mousePosition.x - _rect.width / 2f;
            _rect.y = Event.current.mousePosition.y - _rect.height / 2f;
        }
        GUI.Button(_rect, "On");
    }
}

public partial class HiDebugView : MonoBehaviour
{
    void Panel()
    {
        if (_eDisplay != EDisplay.Panel)
            return;


        GUILayout.Window(0, new Rect(0, 0, Screen.width, Screen.height * _panelHeight), LogWindow, "HiDebug");
        //GUI.Window(1, new Rect(0, Screen.height * _panelHeight, Screen.width, Screen.height), StackWindow, "");

    }

    private bool _isLogOn = true;
    private bool _isWarnningOn = true;
    private bool _isErrorOn = true;
    void LogWindow(int windowID)
    {
        if (GUI.Button(new Rect(0, 0, Screen.width * _buttonWidth, Screen.height * _buttonHeight), "Clear"))
        {

        }
        if (GUI.Button(new Rect(Screen.width * (1 - _buttonWidth), 0, Screen.width * _buttonWidth, Screen.height * _buttonHeight), "Close"))
        {
            _eDisplay = EDisplay.Button;
        }
        var headHight = GUI.skin.window.padding.top;//height of head
        var logStyle = GetGUIStype(new GUIStyle(GUI.skin.toggle), Color.white);
        _isLogOn = GUI.Toggle(new Rect(Screen.width * 0.3f, headHight, Screen.width * _buttonWidth, Screen.height * _buttonHeight), _isLogOn, "Log", logStyle);
        var WarnningStyle = GetGUIStype(new GUIStyle(GUI.skin.toggle), Color.yellow);
        _isWarnningOn = GUI.Toggle(new Rect(Screen.width * 0.5f, headHight, Screen.width * _buttonWidth, Screen.height * _buttonHeight), _isWarnningOn, "Warnning", WarnningStyle);
        var errorStyle = GetGUIStype(new GUIStyle(GUI.skin.toggle), Color.red);
        _isErrorOn = GUI.Toggle(new Rect(Screen.width * 0.7f, headHight, Screen.width * _buttonWidth, Screen.height * _buttonHeight), _isErrorOn, "Error", errorStyle);

        //GUI.Label(new Rect(0, Screen.height * _buttonHeight, Screen.width, Screen.height * _panelHeight), "dfdsdsdsdsdsd" +
        //                                                                                                  "fadfadsfffffffffffffffffffffsdsdsdsdsdsdsdsdsdsdsdsfdsafadsfa" +
        //                                                                                                  "sdfaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
        //                                                                                                  "dsdsdsdsdsdssafds");

        //GUILayout.Label("dfdsdsdsdsdsd" +
        //                "fadfadsfffffffffffffffffffffsdsdsdsdsdsdsdsdsdsdsdsfdsafadsfa" +
        //                "sdfaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
        //                "dsdsdsdsdsdssafds", GUI.skin.label);
        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUI.skin.scrollView);
        GUILayout.Label("dfdsdsdsdsdsd" +
                        "fadfadsfffffffffffffffffffffsdsdsdsdsdsdsdsdsdsdsdsfdsafadsfa" +
                        "sdfaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                        "dsdsdsdsdsdssafds", GUI.skin.label);
        GUILayout.EndScrollView();


    }
    private Vector2 _scrollPosition;
    void StackWindow(int windowID)
    {

    }

    GUIStyle GetGUIStype(GUIStyle guiStyle, Color color)
    {
        guiStyle.normal.textColor = color;
        guiStyle.hover.textColor = color;
        guiStyle.active.textColor = color;
        guiStyle.onNormal.textColor = color;
        guiStyle.onHover.textColor = color;
        guiStyle.onActive.textColor = color;
        return guiStyle;
    }
}