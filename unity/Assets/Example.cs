using UnityEngine;
public class Example : MonoBehaviour
{
    void Start()
    {
        MyDebug.fontSize = 20;

        //MyDebug.EnableOnConsole(false); 
        MyDebug.EnableOnScreen(true);
        MyDebug.EnableOnText(true);//写入到text文件中(persistent目录下)
        MyDebug.EnableFps(true);
    }
    int i = 0;
    void Update()
    {
        if (i < 500)
        {
            i++;
            MyDebug.Log(i);
        }
    }
}
