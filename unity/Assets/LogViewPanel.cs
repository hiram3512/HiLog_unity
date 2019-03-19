using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityLogHelper
{
    internal partial class LogView
    {
        private float _panelHeight = 0.7f;
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
