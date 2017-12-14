//****************************************************************************
// Description:hidebug's view logic
// Author: hiramtan@live.com
//****************************************************************************

#define HiDebug_CurrentMouse

using UnityEngine;
public partial class HiDebugView : MonoBehaviour
{
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
    Rect _rect = new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.1f);
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

        Rect _rect = new Rect(0, 0, Screen.width, Screen.height * 0.7f);
        GUI.Window(0, _rect, PanelWindow, "HiDebug");
    }

    //private bool _isLogOn = true;
    //private bool _isWarnningOn = true;
    //private bool _isErrorOn = true;
    void PanelWindow(int windowID)
    {
        //if (GUILayout.Button("Please click me a lot"))
        //    print("Got a click");

        if (GUI.Button(new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.1f), "Clear"))
        {

        }
        if (GUI.Button(new Rect(Screen.width * 0.8f, 0, Screen.width * 0.2f, Screen.height * 0.1f), "Close"))
        {
            _eDisplay = EDisplay.Button;
        }
        //_isLogOn = GUI.Toggle(new Rect(Screen.width * 0.4f, 0, Screen.width * 0.1f, Screen.height * 0.1f), _isLogOn, "Log");
    }
}