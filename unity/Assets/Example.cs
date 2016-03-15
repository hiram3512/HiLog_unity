using UnityEngine;
public class Example : MonoBehaviour
{
    void Start()
    {
        MyDebug.EnabelOnScreen(true);
        MyDebug.EnabelOnText(true);//写入到text文件中(persistent目录下)
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