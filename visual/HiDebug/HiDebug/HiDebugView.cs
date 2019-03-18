/**************************************************************************
 * Description: hidebug's view logic
 *  
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public partial class HiDebugView : MonoBehaviour
{
    private static float _buttonWidth = 0.2f;
    private static float _buttonHeight = 0.1f;
    private static float _panelHeight = 0.7f;//0.3 is for stack

    private enum EDisplay
    {
        Button,//switch button
        Panel,//log panel
    }
    private EDisplay _eDisplay = EDisplay.Button;

    void OnGUI()
    {
        Button();
        Panel();
    }
}