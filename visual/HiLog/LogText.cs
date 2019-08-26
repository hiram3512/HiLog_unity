/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * 
 * Support: hiramtan@live.com    
 *******************************************************************/

using System.IO;
using UnityEngine;

namespace HiLogHelper
{
    internal class LogText
    {
        private string HiLogFilePath
        {
            get { return HiLog.HiLogTextFolder + "/HiLog_" + LogTime.GetDate() + ".txt"; }
        }

        public LogText()
        {
            LogScreen.OnClearButtonClick = OnClear;
        }

        /// <summary>
        /// Write log in text
        /// For editor path is dataPath, and for other platform path is persistentDataPath
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="stackTrace"></param>
        /// <param name="type"></param>
        public void Text(string condition, string stackTrace, LogType type)
        {
            var typeInfo = string.Format("[{0}]", type.ToString());
            var log = typeInfo + LogTime.GetTimeFormat() + condition;
            var sw = File.AppendText(HiLogFilePath);
            sw.WriteLine(log + "\n" + stackTrace);
            sw.Close();
        }

        private void OnClear()
        {
            File.WriteAllText(HiLogFilePath, string.Empty);
        }
    }
}