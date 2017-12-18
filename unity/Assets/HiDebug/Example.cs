////****************************************************************************
//// Description:
//// 1.程序开发过程中需要一直显示日志,发布时为了节省性能需要关闭日志,如果使用unity自带的Debug类,
////    只能一条条的删掉日志,并且有些日志还想继续保留方便使用开发时使用---通过EnableOnConsole就可以方便解决这个问题.
//// 2.unity的Debug输出日志时并没有携带时间,如果使用Debuger输出的日志自动加时间戳,方便调试时和其他
////    开发者核对日志(比如服务器说七点发了xx消息)
//// 3.在屏幕上显示:这个功能很好用,原因在于在真机调试时如果想看日志,必须安装Android studio,xcode等软件,并且还夹杂了很多系统
////    日志需要过滤,有这个功能后可以直接把日志显示在屏幕(手指点击仍旧可以穿透,仅仅显示在最上层)可以拖动滚动条查看日志方便真机调试.
//// 4.写入日志到本地文本文件(pc和真机都生成在persistent目录下),方便查看崩溃时的日志和几天前的日志.
//// 5.如果在开发过程中想看一下FPS(帧率)可以使用EnableFps方法开启
////
//// 其他功能看Others介绍
////
//// Author: hiramtan@qq.com
////****************************************************************************
//using UnityEngine;
//public class Example : MonoBehaviour
//{
//    void Start()
//    {
//        Debuger.EnableHiDebugLogs(true); //disable on console
//        Debuger.EnableOnScreen(true);//disable on screen
//        Debuger.EnableOnText(true);//write in text(persistent folder)
//        Debuger.EnableFps(true);//display fps

//        Log();
//    }
//   void Log()
//    {
//        for (int i = 0; i < 5; i++)
//            Debuger.Log("log: " + i);
//        for (int i = 0; i < 5; i++)
//            Debuger.LogWarning("warning: " + i);
//        for (int i = 0; i < 5; i++)
//            Debuger.LogError("error: " + i);
//    }

//    void OtherSetting()
//    {
//        Debuger.FontSize = 20;
//        Debuger.ItemCountOnScreen = 100;
//    }
//}
