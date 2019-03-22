/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using UnityEngine;

namespace UnityLogHelper
{
    internal partial class LogScreen
    {
        private enum EMouse
        {
            Up,
            Down,
        }
        private readonly float _mouseClickTime = 0.2f;//less than this is click
        private static float _buttonWidth = 0.2f;
        private static float _buttonHeight = 0.1f;

        private EMouse _eMouse = EMouse.Up;
        private float _mouseDownTime;
        private Rect _rect = new Rect(0, 0, Screen.width * _buttonWidth, Screen.height * _buttonHeight);
        void Button()
        {
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
            if (_eMouse == EMouse.Down && Event.current.type == EventType.MouseDrag)
            {
                _rect.x = Event.current.mousePosition.x - _rect.width / 2f;
                _rect.y = Event.current.mousePosition.y - _rect.height / 2f;
            }
            GUI.Button(_rect, "On", GetGUISkin(GUI.skin.button, Color.white, TextAnchor.MiddleCenter));
        }
    }
}
