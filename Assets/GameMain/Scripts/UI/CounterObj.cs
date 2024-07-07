using System;
using Assets.GameMain.Scripts.Logic.Input;
using QFramework;
using UnityEngine;

namespace GameMain.Scripts.UI
{
    public class CounterObj : IDisposable
    {
        private Action OnCounterSuccess;

        public CounterObj(Action action)
        {
            OnCounterSuccess = action;
            InputManager.Instance.OnCounterInput += OnCounter;
        }
        

        private void OnCounter()
        {
            // do sth
            Debug.Log("Counter Success");
            OnCounterSuccess?.Invoke();
            
            Dispose();
        }
        
        public void Dispose()
        {
            InputManager.Instance.OnCounterInput -= OnCounter;
        }
    }
}