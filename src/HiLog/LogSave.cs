/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using UnityEngine;

namespace HiLog
{
    internal class LogSave
    {
        public static string Path;
        public static void Init()
        {
            string fileName = string.Format("{0}{1}", LogTime.GetCurrentTime(), ".txt");
            Path = string.Format("{0}\\{1}", GetDirectory(), fileName);
            Application.logMessageReceivedThreaded += LogCallback;
        }

        private static string GetDirectory()
        {
            string path = Application.persistentDataPath;
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.LinuxEditor)
            {
                path = System.IO.Directory.GetParent(Application.dataPath).FullName;
            }
            string folderName = "HiLog";
            path = string.Format("{0}\\{1}", path, folderName);
            bool isExists = System.IO.Directory.Exists(path);
            if (isExists)
            {
                System.IO.Directory.Delete(path, true);
            }
            System.IO.Directory.CreateDirectory(path);
            return path;
        }

        private static void LogCallback(string condition, string stackTrace, LogType type)
        {
            string header = string.Format("[{0}][{1}]", LogTime.GetCurrentTime(), type);
            string text = string.Format("{0}{1}", header, condition);
            if (type != LogType.Log)
            {
                text = string.Format("{0}{1}{2}", text, "\n", stackTrace);
            }
            var sw = System.IO.File.AppendText(Path);
            sw.WriteLine(text);
            sw.Close();
        }
    }
}
