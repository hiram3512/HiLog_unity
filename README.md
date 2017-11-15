#HiDebug_unity
----------------------
[中文说明](https://github.com/hiramtan/HiDebug_unity/releases)


### How to use
 you can download unity package from here: [![Github Releases](https://img.shields.io/github/downloads/atom/atom/latest/total.svg)](https://github.com/hiramtan/HiDebug_unity/releases)

-------

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


#### 功能说明
> - 兼容所有平台（编辑器，pc，Android，iOS，WP..）
> - 一键控制Log是否输出(开发阶段开启Log开关,正式版本一键关闭Log输出)
> - 自动记录Log日志时间
> - 是否将Log显示在屏幕(手机查看方便),并可以拖拽拖动条查看旧日志,默认显示100条(可修改显示个数)
> - 是否将Log显示在控制台:像unity的Debug.Log一样显示在unity3d Console窗口
> - 是否将日志写入本地文本文件,方便查找日志(会生成在每个平台的可读写目录下: persistent文件夹)
> - 是否显示当前帧率(FPS)

##### 使用方法
从此链接[https://github.com/hiramtan/HiDebug_unity/releases](https://github.com/hiramtan/HiDebug_unity/releases)下载unitypackage导入到自己的项目中.

开启方法也非常简单(具体参考示例项目):

        Debuger.EnableOnConsole(false); 
        //Debuger.EnableOnScreen(true);
        //Debuger.EnableOnText(true);//写入到text文件中(persistent目录下)
        Debuger.EnableFps(true);
        

[![](https://i1.wp.com/hiramtan.files.wordpress.com/2017/08/20160606212804163.png?ssl=1&w=450)](https://i1.wp.com/hiramtan.files.wordpress.com/2017/08/20160606212804163.png?ssl=1&w=450)

[![](https://i1.wp.com/hiramtan.files.wordpress.com/2017/08/20160606213032591.png?ssl=1&w=450)](https://i1.wp.com/hiramtan.files.wordpress.com/2017/08/20160606213032591.png?ssl=1&w=450)

> **Tip:**
> - 可以修改屏幕上Log日志的文字大小及颜色(包括显示的FPS字体大小)

support: hiramtan@live.com
