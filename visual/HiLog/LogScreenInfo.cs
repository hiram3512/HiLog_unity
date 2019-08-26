/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using System;
using UnityEngine;
namespace HiLogHelper
{
    public class LogScreenInfo
    {
        public string Condition { get; private set; }
        public string StackTrace { get; private set; }
        public LogType Type { get; private set; }

        public LogScreenInfo(string condition, string stackTrace, LogType type)
        {
            this.Condition = LogTime.GetTime() + condition;
            this.StackTrace = stackTrace;
            this.Type = type;
        }
    }
}
