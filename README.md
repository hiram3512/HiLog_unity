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

### Feature
- HiLog have nothing intrusion with your project, you don't have to modify old logic, of cource still use unity engine interface to output log, just call enable interface at start.
- HiLog have nothing assets, all UI made by logic, these means won't increase size of your app, or don't need think about if the assets have be packaged.
- All functions is centralized in one dll file, just download and copy into your project. 

### Functionality
- Support all platforms(unity editor, exe, Android, iOS, WP...)
- Add timestamp with user's log(despite new version of unity have this function but it can only in editor platform)
- Write logs into text file.(editor path is in project/mobile path is: application.persistentdatapath)
- Display logs on screen(can quickly check logs and event have not connect Android studio,xcode)
- Display stacks and write stacks into text.
- Only one file and have no relevance with your project

----------------------------

### Screenshot
![ezgif-5-9829fc97d6](others/ezgif-5-9829fc97d6.gif)

![Image15](others/Image15.png)

![Image18](others/Image18.png)

-------------------

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
