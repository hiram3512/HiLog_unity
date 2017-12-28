#HiDebug_unity
----------------------

### 如何使用
 可以从此链接下载最新的unity package: [![Github Releases](https://img.shields.io/github/downloads/atom/atom/latest/total.svg)](https://github.com/hiramtan/HiDebug_unity/releases)

或者从unity asset store下载:

---------

### 功能

>- 支持多平台(unity editor, exe, Android, iOS, WP...).
>- 一键开关日志(开发模式时开启日志,发布模式时一键关闭).
>- 是否将日志打印到屏幕(即便不连接Android studio,xcode也可以查看日志)
>- 是否记录日志到text(默认路径是persistentdatapath,可以在程序崩溃时查看日志)
>- 自动将时间戳添加到日志.
>- 屏幕显示堆栈信息或记录堆栈信息到text.
>- 所有功能都在一个dll中,可以直接复制到工程使用.


### 详情

1. 控制台日志:

``` csharp
Debuger.EnableHiDebugLogs(true);
```

如果使用Debuger.Log or Debuger.LogWarnning or Debuger.LogError打印日志, 你可以一键关闭这些日志Debuger.EnableHiDebugLogs(false).

同时,也会自动将你的日志附加时间戳.

[![](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-18_223835.png)](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-18_223835.png)

当然你倾向使用unity引擎的Debug.Log打印日志,这些日志同样可以打印在屏幕上或记录到txt中.


2. 记录日志到text:

``` csharp
Debuger.EnableOnText(true);
```
将会记录日志和堆栈信息到text,默认路径是Application.persistentDataPath.

[![](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-18_225219.png)](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-18_225219.png)

3. 打印日志到屏幕:

``` csharp
Debuger.EnableOnScreen(true);
```
将会显示一个按钮,可以拖拽到任何地方(不遮挡你的游戏按钮的地方)

当点击这个按钮,将会弹出一个面板展示日志和堆栈.

>- 点击每一条日志可以显示其堆栈信息.
>- 勾选 log 或 warnning 或 error 只显示此类型的日志.
>- 清空屏幕上的所有日志.
>- 关闭日志展示面板
>- 设置屏幕上字体大小.

[![](https://github.com/hiramtan/HiDebug_unity/blob/master/others/ezgif-5-9829fc97d6.gif)](https://github.com/hiramtan/HiDebug_unity/blob/master/others/ezgif-5-9829fc97d6.gif)

----------
#### Example1
```csharp
void Start()
    {
        Use_Debug();
        Use_Debuger();
    }

    /// <summary>
    /// use debuger, you can enable or disable logs just one switch
    /// and also it automatically add time to your logs 
    /// </summary>
    void Use_Debuger()
    {
        //you can set all debuger's out put logs disable just set this value false(pc,android,ios...etc)
        //it's convenient in release mode, just set this false, and in debug mode set this true.
        Debuger.EnableHiDebugLogs(true);
        //Debuger.EnableHiDebugLogs(false);

        Debuger.EnableOnText(true);
        Debuger.EnableOnScreen(true);

        for (int i = 0; i < 100; i++)
        {
            Debuger.Log(i);
            Debuger.LogWarning(i);
            Debuger.LogError(i);
        }
    }

    /// <summary>
    /// if you donnt want use Debuger.Log()/Debuger.LogWarnning()/Debuger.LogError()
    /// you can still let UnityEngine's Debug on your screen or write them into text
    /// </summary>
    void Use_Debug()
    {
        Debuger.EnableOnText(true);
        Debuger.EnableOnScreen(true);

        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i);
            Debug.LogWarning(i);
            Debug.LogError(i);
        }
    }
```
[![](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-19_094412.png)](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-19_094412.png)
#### Example2
``` csharp
[SerializeField]
    private bool _isLogOn;//set this value from inspector
    [SerializeField]
    private bool _isLogOnText;
    [SerializeField]
    private bool _isLogOnScreen;
    // Use this for initialization
    void Start()
    {
        Debuger.EnableHiDebugLogs(_isLogOn);
        Debuger.EnableOnText(_isLogOnText);
        Debuger.EnableOnScreen(_isLogOnScreen);

        for (int i = 0; i < 100; i++)
        {
            Debuger.Log(i);
            Debuger.LogWarning(i);
            Debuger.LogError(i);
        }

        Debuger.FontSize = 20;//set size of font
    }
```


[![](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-19_094920.png)](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-19_094920.png)

#### Example3

使用unity引擎的Debug.Log, 仍然可以打印日志到屏幕,或者记录到text.

``` csharp
[SerializeField]
    private bool _isLogOnText;
    [SerializeField]
    private bool _isLogOnScreen;
    // Use this for initialization
    void Start()
    {
        Debuger.EnableOnText(_isLogOnText);
        Debuger.EnableOnScreen(_isLogOnScreen);


        //unity engine's debug.log
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i);
            Debug.LogWarning(i);
            Debug.LogError(i);
        }
    }
```
[![](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-19_095354.png)](https://github.com/hiramtan/HiDebug_unity/blob/master/others/2017-12-19_095354.png)


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
