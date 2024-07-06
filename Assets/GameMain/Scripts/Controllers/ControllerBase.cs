using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Looper;
using QFramework;
using UnityEngine;

namespace GameMain.Scripts.Controllers
{
    public class ControllerBase : MonoBehaviour, ILooper
    {
        public virtual void OnGameInit() { }
        
        public virtual void OnUpdate(float eclapse) { }

        public virtual void OnFixedUpdate(float eclapse) { }
        
        public virtual void OnGameShutdown() { }
        
        public IArchitecture GetArchitecture()
        {
            return GameCenter.Interface;
        }
    }
}