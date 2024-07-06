using System;
using QFramework;
using UnityEngine.UI;

namespace GameMain.Scripts.Controllers.UI.Counter
{
    public class CounterPanelData : UIPanelData
    {
        public Action OnCounterHappen;
    }
    
    public class CounterPanel : UIPanel
    {
        public Button CounterBtn;
        
        protected override void OnInit(IUIData uiData = null)
        {
            (uiData as CounterPanelData).OnCounterHappen += OnCounter;
        }

        protected override void OnOpen(IUIData uiData = null)
        {
            
        }

        private void OnCounter()
        {
            // do sth
            
            // await
            OnClose();
        }

        protected override void OnClose()
        {
            (mUIData as CounterPanelData).OnCounterHappen -= OnCounter;
        }
    }
}