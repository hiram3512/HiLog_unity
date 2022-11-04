# HiLog_unity
----------------------

![Packagist](https://img.shields.io/packagist/l/doctrine/orm.svg)   [![GitHub release](https://img.shields.io/github/release/hiramtan/HiLog_unity.svg)](https://github.com/hiramtan/HiLog_unity/releases)  [![Github Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/hiramtan/HiLog_unity/releases)

[中文说明](https://github.com/hiramtan/HiLog_unity/blob/master/README_zh.md)

### How to use

```csharp
public class Example : MonoBehaviour
{
    void Start()
    {
        HiLog.Main.EnableLogSave(); //If you want to save log file
        HiLog.Main.EnableLogScreen(); //If you want to show log on screen
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
```

### Screenshot
![Image18](others/Image18.png)

![ezgif-5-9829fc97d6](others/ezgif-5-9829fc97d6.gif)

![Image15](others/Image15.png)

-----

### Feature
- HiLog have nothing intrusion with your project, you don't have to modify old logic, of cource still use unity engine interface to output log, just call enable interface at start.
- HiLog have nothing assets, all UI made by logic, these means won't increase size of your app, or don't need think about if the assets have be packaged.
- All functions is centralized in one dll file, just download and copy into your project. 

### Functionality
- Support all platforms(unity editor, exe, Android, iOS, WP...)
- Add timestamp with user's log(despite new version of unity have this function but it can only in editor platform)
- Write logs into text file.(editor path is in project,mobile path is: application.persistentdatapath)
- Display logs on screen(can quickly check logs and event have not connect Android studio,xcode)
- Display stacks and write stacks into text.
- Only one file and have no relevance with your project

----------------------------
support: hiramtan@live.com
