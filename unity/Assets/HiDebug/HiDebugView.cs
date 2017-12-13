//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

#define HiDebug_CurrentMouse

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HiDebugView : MonoBehaviour
{
    private enum EState
    {
        Button,//switch button
        Panel,//log panel
    }
    private enum EMouse
    {
        None,
        Down,
        Up,
        Click,
        Drag,
    }
    private EState _eState = EState.Button;
    private EMouse _eMouse = EMouse.None;
    private Rect _rect;//button's rect
    //private bool _isMouseOn;//is mouse on this button
    // Use this for initialization
    void Start()
    {
        _rect = new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float _startDownTime;
    private float _clickTime = 0.5f;//less than this is click
    void OnGUI()
    {
        if (_eState == EState.Button)
        {
            //Bug: can not use drag type directly, maybe you hold an button and drag too fast;
            if (_rect.Contains(Event.current.mousePosition))
            {
                if (Event.current.type == EventType.MouseDown)
                {
                    _eMouse = EMouse.Down;
                    _startDownTime = Time.realtimeSinceStartup;
                }
                else if (Event.current.type == EventType.mouseDrag)
                {
                    _eMouse = EMouse.Drag;
                }
                else if (Event.current.type == EventType.MouseUp)
                {
                    if (Time.realtimeSinceStartup - _startDownTime < _clickTime)
                        _eMouse = EMouse.Click;
                    else
                    {
                        _eMouse = EMouse.Up;
                    }
                }
            }
#if HiDebug_CurrentMouse
            if (_eMouse == EMouse.Click)
                Debug.LogError(_eMouse);
            else
                Debug.Log(_eMouse);
#endif
            if (_eMouse == EMouse.Drag)
            {
                _rect.x = Event.current.mousePosition.x - _rect.width / 2f;
                _rect.y = Event.current.mousePosition.y - _rect.height / 2f;
            }
            if (_eMouse == EMouse.Click)
            {
                _eState = EState.Panel;
            }
            GUI.Button(_rect, "On");
        }
    }
}
