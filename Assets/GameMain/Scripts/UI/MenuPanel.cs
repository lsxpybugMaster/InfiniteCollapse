using System.Collections.Generic;
using QFramework;
using UnityEngine.UI;

namespace GameMain.Scripts.UI
{
    public class MainMenuPanelData : UIPanelData
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