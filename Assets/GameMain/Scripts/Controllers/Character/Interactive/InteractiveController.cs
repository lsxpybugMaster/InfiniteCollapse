using System;
using Assets.GameMain.Scripts.Character.Player;
using GameMain.Scripts.Controllers.UI.Counter;
using QFramework;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace GameMain.Scripts.Controllers.Character.Interactive
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class InteractiveController : ControllerBase
    {
        protected Collider2D mColl;

        [Title("Attribute")]
        public float InitSpeed;
        public float Mass;
        [Space]
        [WarnBeforeEditing("未填写", "必须填碰撞范围")]
        public float InnerRadius;
        [EnableIf("CanCounter")]
        [WarnBeforeEditing("未填写", "可以填交互物范围")]
        public float OuterRadius;

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

        public override void OnUpdate(float eclapse)
        {
            CheckCollision();
        }


        public virtual void OnInnerCollision(ControllerBase other)
        {
            if (other is PlayerController player)
            {
                player.OnCollisionWithInteractive(controller =>
                {
                    controller.mMovementComp.DecreaseForwardSpeed(SpeedDownNumOnCollide);
                });
            }
        }

        private void CheckCollision()
        {
            if (CanCounter)
            {
                var outerColl = Physics2D.OverlapCircle(transform.position, OuterRadius);
                if (outerColl != null && outerColl.TryGetComponent(out PlayerController player))
                {
                    OnOuterEnter(player);
                }
            }

            var innerColl = Physics2D.OverlapCircle(transform.position, InnerRadius);
            if (innerColl != null)
            {
                OnInnerCollision(innerColl.GetComponent<ControllerBase>());
            }

        }
        
        public virtual void OnOuterEnter(PlayerController player)
        {
            
        }
    }
}