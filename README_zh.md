#HiDebug_unity
----------------------
[中文说明](https://github.com/hiramtan/HiDebug_unity/releases)


### How to use
 You can download unity package from here: [![Github Releases](https://img.shields.io/github/downloads/atom/atom/latest/total.svg)](https://github.com/hiramtan/HiDebug_unity/releases)


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

***********

MIT License

Copyright (c) [2017] [Hiram]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
