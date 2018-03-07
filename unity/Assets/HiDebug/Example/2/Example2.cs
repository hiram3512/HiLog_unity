//****************************************************************************
// Description:download newest version from: https://github.com/hiramtan/HiDebug_unity/releases
// Author: hiramtan@live.com
//****************************************************************************

using UnityEngine;

public class Example2 : MonoBehaviour
{
    [SerializeField]
    private bool _isLogOn;//set this value from inspector
    [SerializeField]
    private bool _isLogOnText;
    [SerializeField]
    private bool _isLogOnScreen;
    // Use this for initialization
    void Start()
    {
        HiDebug.EnableDebuger(_isLogOn);
        HiDebug.EnableOnText(_isLogOnText);
        HiDebug.EnableOnScreen(_isLogOnScreen);
        for (int i = 0; i < 100; i++)
        {
            Debuger.Log(i);
            Debuger.LogWarning(i);
            Debuger.LogError(i);
        }
        HiDebug.FontSize = 20;//set size of font
    }
}
