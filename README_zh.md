# HiLog_unity
----------------------
![Packagist](https://img.shields.io/packagist/l/doctrine/orm.svg)   [![GitHub release](https://img.shields.io/github/release/hiramtan/HiLog_unity.svg)](https://github.com/hiramtan/HiLog_unity/releases)  [![Github Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/hiramtan/HiLog_unity/releases)

### 如何使用

```csharp
public class Example : MonoBehaviour
{
    void Start()
    {
        HiLog.Main.EnableLogSave(); //If you want save log file
        HiLog.Main.EnableLogScreen(); //If you want show log on screen
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

### 特点
- HiLog 不会干扰原有的逻辑,不用修改之前的逻辑,日志输出还是使用引擎接口,只需要调用一下初始化接口.
- HiLog 没有任何资源,所有的UI界面用逻辑实现,因此不会增加包体大小,也不用操心资源是否正常打包等.
- 所有的功能在一个dll中,下载拷贝到项目中就可以使用. 

### 功能说明
- 支持多平台(unity editor, exe, Android, iOS, WP...)
- 日志添加时间戳，虽然新版unity日志具有时间戳功能，但是只是针对编辑器，HiLog所有日志全部添加时间戳功能。
- 记录日志到text文件中(编辑器在项目目录下/移动端文件路径在persistentdatapath)
- 是否将日志打印到屏幕(即便不连接Android studio,xcode也可以查看日志)
- 屏幕显示堆栈信息或记录堆栈信息到text.
- 插件小巧,与原有项目无耦合.

----------------------------

### 截图
![ezgif-5-9829fc97d6](others/ezgif-5-9829fc97d6.gif)

![Image15](others/Image15.png)

![Image18](others/Image18.png)

-------------------

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
