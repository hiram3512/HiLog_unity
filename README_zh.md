#HiDebug_unity
----------------------

### 如何使用
 可以从此链接下载最新的unity package: [![Github Releases](https://img.shields.io/github/downloads/atom/atom/latest/total.svg)](https://github.com/hiramtan/HiDebug_unity/releases)


### 功能
---------
>- 支持多平台(unity编辑器, exe, Android, iOS, WP...).
>- 一键开启关闭日志.
>- 是否将日志显示在控制台.
>- 是否将日志显示在屏幕(可以不用连接Android Studio,Xcode就可以查看日志)
>- 是否将日志写入文本文件(默认在persistent目录中,方便崩溃时查看)
>- 日志附加时间戳
>- 是否显示FPS

#### 示例
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
>- 可以设置屏幕字体大小
>- 可以设置屏幕显示日志数量

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
