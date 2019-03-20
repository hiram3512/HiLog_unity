/*******************************************************************
 * Documents: https://github.com/hiramtan/HiLog_unity
 * Support: hiramtan@live.com    
 *******************************************************************/

using UnityEngine;

namespace UnityLogHelper
{
    internal partial class LogView : MonoBehaviour
    {
        private enum EDisplay
        {
            Button,
            Panel,
        }

        private EDisplay _eDisplay = EDisplay.Button;

        void OnGUI()
        {
            if (_eDisplay == EDisplay.Button)
            {
                Button();
            }
            else if (_eDisplay == EDisplay.Panel)
            {
                Panel();
            }
        }

        GUIStyle GetGUISkin(GUIStyle guiStyle, Color color, TextAnchor style)
        {
            guiStyle.normal.textColor = color;
            guiStyle.hover.textColor = color;
            guiStyle.active.textColor = color;
            guiStyle.onNormal.textColor = color;
            guiStyle.onHover.textColor = color;
            guiStyle.onActive.textColor = color;
            guiStyle.margin = new RectOffset(0, 0, 0, 0);
            guiStyle.alignment = style;
            guiStyle.fontSize = HiLog.FontSizeOnScreen;
            return guiStyle;
        }
    }
}