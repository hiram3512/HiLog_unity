using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace UnityLogHelper
{
   public class LogViewInfo
    {
        public string Condition { get; private set; }
        public string StackTrace { get; private set; }
        public LogType Type { get; private set; }

        public LogViewInfo(string condition, string stackTrace, LogType type)
        {
            this.Condition = condition;
            this.StackTrace = stackTrace;
            this.Type = type;
        }
    }
}
