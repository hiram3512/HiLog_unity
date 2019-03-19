using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiLog
{
    public partial class LogView
    {
        private List<LogViewInfo> _logViewInfos = new List<LogViewInfo>();
        public void NewLog(LogViewInfo log)
        {
            _logViewInfos.Add(log);
        }

        void Panel()
        {

        }
    }
}
