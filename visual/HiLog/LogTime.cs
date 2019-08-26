/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * 
 * Support: hiramtan@live.com    
 *******************************************************************/

using System;

namespace HiLogHelper
{
    internal static class LogTime
    {
        internal static string GetTimeFormat()
        {
            var str = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            return string.Format("[{0}]", str);
        }

        internal static string GetDate()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
    }
}