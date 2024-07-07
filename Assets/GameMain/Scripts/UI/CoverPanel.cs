using System;
using QFramework;
using UnityEngine;

namespace GameMain.Scripts.UI
{
    public class CoverPanel : UIPanel
    {
        public Action pressEnter;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                pressEnter?.Invoke();
                CloseSelf();
            }
        }

        protected override void OnClose()
        {
        }
    }
}
