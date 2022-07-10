/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using System;

namespace HiLog
{
    internal static class LogTime
    {
        public static string GetCurrentTime()
        {
            return DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff");
        }
    }
}