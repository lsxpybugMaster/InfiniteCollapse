using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace GameMain.Scripts.UI
{
    public class MenuPanelData : UIPanelData
    {
    }
    
    public class MenuPanel : UIPanel
    {
        public List<Button> levelSelectBtns = new List<Button>();

        protected override void OnClose()
        {
        }
    }
}