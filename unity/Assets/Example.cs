/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using System;
using UnityEngine;

public class Example : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

#if UNITY_EDITOR
        HiLog.HiLogTextFolder = Application.dataPath + "/..";
#else
        HiLog.HiLogTextFolder = Application.persistentDataPath;
#endif

        HiLog.SetOn();
        Log();
    }

    void Log()
    {
        Debug.Log("this is from start");
        Debug.Log(123);
        Debug.LogWarning(456);
        Debug.LogError(789);
    }
}
