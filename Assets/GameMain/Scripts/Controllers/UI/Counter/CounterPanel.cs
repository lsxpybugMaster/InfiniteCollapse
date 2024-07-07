using System;
using Assets.GameMain.Scripts.Logic.Input;
using GameMain.Scripts.Controllers.Character.Interactive;
using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace GameMain.Scripts.Controllers.UI.Counter
{
    public class CounterPanelData : UIPanelData
    {
        public Action OnCounterSuccess = null;

        public CounterPanelData(Action action)
        {
            OnCounterSuccess = action;
        }
    }
    
    public class CounterPanel : UIPanel
    {
        public Button CounterBtn;
        
        protected override void OnInit(IUIData uiData = null)
        {
            InputManager.Instance.OnCounterInput += OnCounter;
            
        }

        protected override void OnOpen(IUIData uiData = null)
        {
            
        }

        private void OnCounter()
        {
            // do sth
            Debug.Log("Counter Success");
            (mUIData as CounterPanelData).OnCounterSuccess?.Invoke();
            
            // await
            OnClose();
        }

        protected override void OnClose()
        {
            InputManager.Instance.OnCounterInput -= OnCounter;
        }
    }
}