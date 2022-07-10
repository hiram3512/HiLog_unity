/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        HiLog.Main.EnableLogSave(); //If you want save log file
        HiLog.Main.EnableLogScreen(); //If you want show log on screen
    }
    int numb = 0;
    private void Update()
    {
        numb++;
        Debug.Log(numb);
        Debug.Log(numb);
        Debug.Log(numb);
        Debug.Log(numb);
        Debug.Log(numb);
        Debug.LogWarning(numb);
        Debug.LogError(numb);
    }
}
