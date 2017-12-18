//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using UnityEngine;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debuger.EnableOnScreen(true);
        Debuger.EnableOnText(true);


        Log();
    }




    /// <summary>
    /// use debuger, you can enable or disable just one switch
    /// and also it automatically add time to your logs 
    /// </summary>
    void Use_Debuger()
    {
        //you can set all debuger's out put logs disable just set this value false(pc,android,ios...etc)
        //it's convenient in release mode, just set this false, and in debug mode set this true.
        Debuger.EnableHiDebugLogs(true);
        //Debuger.EnableHiDebugLogs(false);

        Debuger.EnableOnText(true);
        Debuger.EnableOnScreen(true);
    }


    /// <summary>
    /// if you donnt want use Debuger.Log()/Debuger.LogWarnning()/Debuger.LogError()
    /// you can still let UnityEngine's Debug on your screen or write them into text
    /// </summary>
    void Use_Debug()
    {
        Debuger.EnableOnText(true);
        Debuger.EnableOnScreen(true);
    }


    void Log()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i);
            Debug.LogWarning(i);
            Debug.LogError(i);
        }
    }
}
