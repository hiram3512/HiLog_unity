/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnityLogHelper
{
    internal partial class LogScreen
    {
        private bool _isLogOn = true;
        private bool _isWarnningOn = true;
        private bool _isErrorOn = true;
        private float _panelHeight = 0.7f;
        private Vector2 _scrollLogPosition;
        private Vector2 _scrollStackPosition;
        private LogScreenInfo _currentSelectedLogScreenInfo;
        private List<LogScreenInfo> _logInfos = new List<LogScreenInfo>();
        public void NewLog(LogScreenInfo logScreen)
        {
            _logInfos.Add(logScreen);
        }

        void Panel()
        {
            GUI.Window(0, new Rect(0, 0, Screen.width, Screen.height * _panelHeight), LogWindow, "HiLog", GetGUISkin(GUI.skin.window, Color.white, TextAnchor.UpperCenter));
            GUI.Window(1, new Rect(0, Screen.height * _panelHeight, Screen.width, Screen.height * (1 - _panelHeight)), StackWindow, "Stack", GetGUISkin(GUI.skin.window, Color.white, TextAnchor.UpperCenter));
        }

        void LogWindow(int windowID)
        {
            if (GUI.Button(new Rect(0, 0, Screen.width * _buttonWidth, Screen.height * _buttonHeight), "Clear", GetGUISkin(GUI.skin.button, Color.white, TextAnchor.MiddleCenter)))
            {
                _currentSelectedLogScreenInfo = null;
                _logInfos.Clear();
                if (File.Exists(HiLog.HiLogTextPath))
                {
                    File.WriteAllText(HiLog.HiLogTextPath, string.Empty);
                }
            }
            if (GUI.Button(new Rect(Screen.width * (1 - _buttonWidth), 0, Screen.width * _buttonWidth, Screen.height * _buttonHeight), "Close", GetGUISkin(GUI.skin.button, Color.white, TextAnchor.MiddleCenter)))
            {
                _eDisplay = EDisplay.Button;
            }
            var headHeight = GUI.skin.window.padding.top;//height of head
            var logStyle = GetGUISkin(GUI.skin.toggle, Color.white, TextAnchor.UpperLeft);
            _isLogOn = GUI.Toggle(new Rect(Screen.width * 0.3f, headHeight, Screen.width * _buttonWidth, Screen.height * _buttonHeight - headHeight), _isLogOn, "Log", logStyle);
            var WarnningStyle = GetGUISkin(GUI.skin.toggle, Color.yellow, TextAnchor.UpperLeft);
            _isWarnningOn = GUI.Toggle(new Rect(Screen.width * 0.5f, headHeight, Screen.width * _buttonWidth, Screen.height * _buttonHeight - headHeight), _isWarnningOn, "Warnning", WarnningStyle);
            var errorStyle = GetGUISkin(GUI.skin.toggle, Color.red, TextAnchor.UpperLeft);
            _isErrorOn = GUI.Toggle(new Rect(Screen.width * 0.7f, headHeight, Screen.width * _buttonWidth, Screen.height * _buttonHeight - headHeight), _isErrorOn, "Error", errorStyle);

            GUILayout.Space(Screen.height * _buttonHeight - headHeight);
            _scrollLogPosition = GUILayout.BeginScrollView(_scrollLogPosition);
            LogItem();
            GUILayout.EndScrollView();
        }

        void LogItem()
        {
            for (int i = 0; i < _logInfos.Count; i++)
            {
                if (_logInfos[i].Type == LogType.Log)
                {
                    if (!_isLogOn)
                        continue;
                }
                else if (_logInfos[i].Type == LogType.Warning)
                {
                    if (!_isWarnningOn)
                        continue;
                }
                else if (_logInfos[i].Type == LogType.Error)
                {
                    if (!_isErrorOn)
                        continue;
                }
                if (GUILayout.Button(_logInfos[i].Condition, GetGUISkin(GUI.skin.button, GetColor(_logInfos[i].Type), TextAnchor.MiddleLeft)))
                {
                    _currentSelectedLogScreenInfo = _logInfos[i];
                }
            }
        }
        void StackWindow(int windowID)
        {
            _scrollStackPosition = GUILayout.BeginScrollView(_scrollStackPosition);
            StackItem();
            GUILayout.EndScrollView();
        }

        void StackItem()
        {
            if (_currentSelectedLogScreenInfo == null)
                return;
            var strs = _currentSelectedLogScreenInfo.StackTrace.Split('\n');
            for (int i = 0; i < strs.Length; i++)
            {
                GUILayout.Label(strs[i], GetGUISkin(GUI.skin.label, GetColor(_currentSelectedLogScreenInfo.Type), TextAnchor.MiddleLeft));
            }
        }

        Color GetColor(LogType type)
        {
            if (type == LogType.Log)
                return Color.white;
            if (type == LogType.Warning)
                return Color.yellow;
            if (type == LogType.Error)
                return Color.red;
            if (type == LogType.Exception)
                return Color.red;
            return Color.white;
        }
    }
}
