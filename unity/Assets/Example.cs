using UnityEngine;
public class Example : MonoBehaviour
{
    void Start()
    {
        Debuger.FontSize = 20;

        Debuger.EnableOnConsole(false); 
        //Debuger.EnableOnScreen(true);
        //Debuger.EnableOnText(true);//写入到text文件中(persistent目录下)
        Debuger.EnableFps(true);
    }
    int i = 0;
    void Update()
    {
		Debug.Log(Input.touchCount);
        if (i < 500)
        {
            i++;
            string tempLog = "this is a log: " + i;
            if (i % 10 == 0)
                Debuger.LogWarning(tempLog);
            else if (i % 5 == 0)
                Debuger.LogError(tempLog);
            else
                Debuger.Log(tempLog);
        }
    }
}
