using System;
using GameMain.Scripts.Controllers.UI.Counter;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameMain.Scripts.Controllers.Character.Interactive
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class InteractiveController : ControllerBase
    {
        protected Collider2D mColl;

        public float InitSpeed;
        public float Mass;

        [InfoBox("碰撞会减少玩家的速度值")]
        public float SpeedDownNumOnCollide;

        public bool CanCounter;

        protected Action<InteractiveController> onCounterSuccess;

        public override void OnGameInit()
        {
            base.OnGameInit();
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            mColl = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ControllerBase controller))
            {
                OnCollision(controller);
            }
        }

        public abstract void OnCollision(ControllerBase other);
        
    }
}