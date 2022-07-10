
/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using UnityEngine;

namespace HiLog
{
    public class Main
    {
        public static void EnableLogSave()
        {
            LogSave.Init();
            Debug.Log("HiLog EnableLogSave:" + LogSave.Path);
        }
        public static void EnableLogScreen()
        {
            new GameObject("HiLog").AddComponent<LogScreen>().Init(); 
            Debug.Log("HiLog EnableLogScreen");
        }
    }
}