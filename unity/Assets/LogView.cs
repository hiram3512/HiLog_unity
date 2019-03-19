using System.Collections.Generic;
using UnityEngine;

namespace HiLog
{
    public partial class LogView : MonoBehaviour
    {
        private enum EDisplay
        {
            Button,
            Panel,
        }

        private float _buttonWidth = 0.2f;
        private float _buttonHeight = 0.1f;
        private float _panelHeight = 0.7f;

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
    }
}