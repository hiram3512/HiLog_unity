# HiLog_unity
----------------------

### 如何使用
HiLog对原有项目没有任何影响，只需要添加一句逻辑便可以开启HiLog的所有功能。
```csharp
HiLog.SetOn(true);
```
所有的功能仅在一个dll文件中，下载后复制到自己的项目中即可

dll下载链接 [![Github Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/hiramtan/HiLog_unity/releases)

### 功能说明
>- 支持多平台(unity editor, exe, Android, iOS, WP...)
>- 日志添加时间戳，虽然新版unity日志具有时间戳功能，但是只是针对编辑器，HiLog所有日志全部添加时间戳功能。
>- 记录日志到text文件中（文件路径在persistentdatapath）
>- 是否将日志打印到屏幕(即便不连接Android studio,xcode也可以查看日志)
>- 屏幕显示堆栈信息或记录堆栈信息到text.
>- 插件小巧,所有功能都在一个dll中,可以直接复制到工程使用,与原有项目无耦合.

### 截图说明
![ezgif-5-9829fc97d6](others/ezgif-5-9829fc97d6.gif)
![2017-12-18_223835](others/2017-12-18_223835.png)
![Image15](others/Image15.png)
![Image17](others/Image17.png)
![Image18](others/Image18.png)

-------------------

### 详情

如果在unity5.x和之前的版本中使用,从此处下载：[https://github.com/hiramtan/HiLog_unity/tree/Branch_2.4.1](https://github.com/hiramtan/HiLog_unity/tree/Branch_2.4.1)

将会记录日志和堆栈信息到text,默认路径是Application.persistentDataPath.

打印日志到屏幕:将会显示一个按钮,可以拖拽到任何地方(不遮挡你的游戏按钮的地方)

当点击这个按钮,将会弹出一个面板展示日志和堆栈.

>- 点击每一条日志可以显示其堆栈信息.
>- 勾选 log 或 warnning 或 error 只显示此类型的日志.
>- 清空屏幕上的所有日志.
>- 关闭日志展示面板
>- 设置屏幕上字体大小.

Example：
```csharp
public class Example : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        HiLog.SetOn(true);
        Log();
    }

    void Log()
    {
        Debug.Log("this is from start");
        Debug.LogWarning(123);
        Debug.LogError(456);
    }
}
```




点击链接加入QQ群【83596104】：https://jq.qq.com/?_wv=1027&k=5l6rZEr

support: hiramtan@live.com

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