using UnityEngine;
namespace UnityLogHelper
{
    public class LogInfo
    {
        public string Condition { get; private set; }
        public string StackTrace { get; private set; }
        public LogType Type { get; private set; }

        public LogInfo(string condition, string stackTrace, LogType type)
        {
            this.Condition = condition;
            this.StackTrace = stackTrace;
            this.Type = type;
        }
    }
}
