﻿//*********************************************************************
// Description:日志
// Author: hiramtan@live.com
//*********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public sealed class Debuger : MonoBehaviour
{
    /// <summary>
    ///     显示在屏幕上的字体大小
    /// </summary>
    public static int FontSize = 15;

    /// <summary>
    ///     显示在屏幕上多少列日志
    /// </summary>
    public static int ItemCountOnScreen = 100;

    private static bool _isLogOnScreen;
    private static bool _isLogOnConsole;
    private static bool _isLogOnText;
    private static bool _isFpsOn;
    private static readonly List<string> _logOnScreenList = new List<string>();
    private static string _logOnScreen;
    private static Vector2 _scrollPosition;
    private static Debuger _instance;
    private float _count; //总次数
    private float _fps;
    private int _i; //计数器
    private float _lastTime; //记录上次的时间

    private Debuger()
    {
    }

    public static bool EnableOnConsole(bool isLogOnConsole)
    {
        _isLogOnConsole = isLogOnConsole;
        return _isLogOnConsole;
    }

    public static bool EnableOnScreen(bool isLogOnScreen)
    {
        if (isLogOnScreen)
            EnableOnConsole(true);
        _isLogOnScreen = isLogOnScreen;
        if (_instance == null)
        {
            var tempGo = new GameObject("Debuger");
            DontDestroyOnLoad(tempGo);
            _instance = tempGo.AddComponent<Debuger>();
        }
        Application.logMessageReceived += (log, stackTrace, type) => { UpdateScrollPosition(); };
        Application.logMessageReceivedThreaded += (log, stackTrace, type) => { UpdateScrollPosition(); };
        return isLogOnScreen;
    }

    public static bool EnableOnText(bool param)
    {
        if (param)
            EnableOnConsole(true);
        _isLogOnText = param;
        return _isLogOnText;
    }

    public static bool EnableFps(bool param)
    {
        _isFpsOn = param;
        if (_instance == null)
            _instance = new GameObject("Debuger").AddComponent<Debuger>();
        return _isFpsOn;
    }

    public static void Log(object obj)
    {
        if (_isLogOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=white>" + log + "</color>";
            Debug.Log(log);
            if (_isLogOnScreen)
                OnScreen(log);
            if (_isLogOnText)
                WriteLog(log);
        }
    }

    public static void LogWarning(object obj)
    {
        if (_isLogOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=yellow>" + log + "</color>";
            Debug.LogWarning(log);
            if (_isLogOnScreen)
                OnScreen(log);
            if (_isLogOnText)
                WriteLog(log);
        }
    }

    public static void LogError(object obj)
    {
        if (_isLogOnConsole)
        {
            var log = string.Format(GetTime(), obj);
            log = "<color=red>" + log + "</color>";
            Debug.LogError(log);
            if (_isLogOnScreen)
                OnScreen(log);
            if (_isLogOnText)
                WriteLog(log);
        }
    }

    private void OnGUI()
    {
        if (_isLogOnScreen)
        {
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(Screen.width),
                GUILayout.Height(Screen.height));
            var tempGuiStyle = new GUIStyle();
            tempGuiStyle.fontSize = FontSize;
            GUILayout.Label(_logOnScreen, tempGuiStyle);
            GUILayout.EndScrollView();
        }
        if (_isFpsOn)
        {
            var tempGuiStyle = new GUIStyle();
            tempGuiStyle.fontSize = FontSize;
            tempGuiStyle.normal.textColor = Color.red;
            GUI.Label(new Rect(0, 0, Screen.width * 0.3f, Screen.height * 0.1f), _fps.ToString(), tempGuiStyle);
        }
    }

    private void Update()
    {
        if (_isFpsOn)
        {
            _i++;
            _count += Time.timeScale / Time.deltaTime;
            if (Time.realtimeSinceStartup > Time.timeScale + _lastTime)
            {
                _fps = _count / _i;
                _count = _i = 0;
                _lastTime = Time.realtimeSinceStartup;
            }
        }
    }

    private static void UpdateScrollPosition()
    {
        _scrollPosition = new Vector2(_scrollPosition.x, _scrollPosition.y + _logOnScreenList.Count);
    }

    private static void OnScreen(string log)
    {
        _logOnScreenList.Add(log);
        if (_logOnScreenList.Count > ItemCountOnScreen)
            _logOnScreenList.RemoveAt(0);
        _logOnScreen = string.Empty;
        foreach (var s in _logOnScreenList)
            _logOnScreen = string.IsNullOrEmpty(_logOnScreen)
                ? _logOnScreen = s
                : _logOnScreen = _logOnScreen + "\n" + s; //第一行不用换行
    }

    private static string GetTime()
    {
        var time = DateTime.Now;
        return time.ToString("yyyy.MM.dd HH:mm:ss") + ": {0}";
    }

    private static void WriteLog(string param)
    {
        var path = Application.persistentDataPath + "/Debuger.txt";
        var sw = File.AppendText(path);
        sw.WriteLine(param);
        sw.Close();
    }
}