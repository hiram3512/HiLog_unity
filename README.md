#HiDebug_unity
----------------------
[中文说明](https://github.com/hiramtan/HiDebug_unity/releases)


### How to use
 you can download unity package from here: [![Github Releases](https://img.shields.io/github/downloads/atom/atom/latest/total.svg)](https://github.com/hiramtan/HiDebug_unity/releases)


### Features
---------
>- Support multiple platform(unity editor, exe, Android, iOS, WP...).
>- Enable or disable logs outputting just in one time.
>- Whether enable logs on unity console.
>- Whether enable logs on screen(so that you can still check logs if you don't want to connect Android Studio or xcode)
>- Whether enable write logs into a text(default path is in persistent folder)
>- Adding data and time append to you logs.
>- Whether display FPS or not.

#### Example
```csharp
void Start()
    {
        Debuger.EnableOnConsole(true); //disable on console
        Debuger.EnableOnScreen(true);//disable on screen
        Debuger.EnableOnText(true);//write in text(persistent folder)
        Debuger.EnableFps(true);//display fps

        Log();
    }
   void Log()
    {
        for (int i = 0; i < 5; i++)
            Debuger.Log("log: " + i);
        for (int i = 0; i < 5; i++)
            Debuger.LogWarning("warning: " + i);
        for (int i = 0; i < 5; i++)
            Debuger.LogError("error: " + i);
    }
```
#### Screenshot
-----------------
[![](https://i1.wp.com/hiramtan.files.wordpress.com/2017/08/20160606212804163.png?ssl=1&w=450)](https://i1.wp.com/hiramtan.files.wordpress.com/2017/08/20160606212804163.png?ssl=1&w=450)

[![](https://i1.wp.com/hiramtan.files.wordpress.com/2017/08/20160606213032591.png?ssl=1&w=450)](https://i1.wp.com/hiramtan.files.wordpress.com/2017/08/20160606213032591.png?ssl=1&w=450)

> **Tip:**
>- You can change font size display on screen.
>- You can set how many logs display on screen.

```csharp
        Debuger.FontSize = 20;
        Debuger.ItemCountOnScreen = 100;
```


support: hiramtan@live.com

qq群:83596104
