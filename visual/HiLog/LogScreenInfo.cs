/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using System;
using UnityEngine;
namespace HiLogHelper
{
    internal class LogScreenInfo
    {
        public string Condition { get; private set; }
        public string StackTrace { get; private set; }
        public LogType Type { get; private set; }

        public LogScreenInfo(string condition, string stackTrace, LogType type)
        {
            this.Condition = LogTime.GetTimeFormat() + condition;
            this.StackTrace = stackTrace;
            this.Type = type;
        }
    }
}
