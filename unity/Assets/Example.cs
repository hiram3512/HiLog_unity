/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using UnityEngine;

public class Example : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        HiLog.SetOn(true);
        Log();
    }

    void Log()
    {
        Debug.Log("this is from start");
        Debug.LogWarning(456);
        Debug.LogError(789);
    }
}
