using System;
using Assets.GameMain.Scripts.Character.Player;
using Assets.GameMain.Scripts.Logic.Input;
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

        private CircleCollider2D mOuterColl;
        private CircleCollider2D mInnerColl;

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

        [InfoBox("除了残骸基本都可以跳qte")]
        public bool CanCounter;

        protected Action onCounterSuccess;
        
        
        // 用于counter成功时, 对player修改
        protected PlayerController mCounterPlayer;

        private bool hasInited = false;

        public override void OnGameInit()
        {
            if (hasInited) return;
            hasInited = true;
            
            base.OnGameInit();
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            mColl = GetComponent<Collider2D>();
            mColl.isTrigger = true;

            mOuterColl = Instantiate(new GameObject("Outer"), transform).AddComponent<CircleCollider2D>();
            mOuterColl.transform.SetParent(transform);
            mInnerColl = Instantiate(new GameObject("Inner"), transform).AddComponent<CircleCollider2D>();
            mInnerColl.transform.SetParent(transform);

            mOuterColl.radius = OuterRadius;
            mInnerColl.radius = InnerRadius;

            mOuterColl.OnTriggerEnter2DEvent(coll =>
            {
                if (coll.TryGetComponent(out PlayerController player))
                {
                    OnOuterEnter(player);
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            mOuterColl.OnTriggerExit2DEvent(coll =>
            {
                if (coll.TryGetComponent(out PlayerController player))
                {
                    UIKit.ClosePanel<CounterPanel>();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);


            mInnerColl.OnTriggerEnter2DEvent(coll => OnInnerCollision(coll.GetComponent<ControllerBase>()))
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            onCounterSuccess = OnCounterSuccess;
        }

        private void Start()
        {
            OnGameInit();
        }

        public override void OnUpdate(float eclapse)
        { 
            //CheckCollision();
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

        public virtual void DestroySelf()
        {
            Destroy(gameObject);
        }

        private bool hasCounterShowed;
        private void CheckCollision()
        {
            if (CanCounter)
            {
                var outerColl = Physics2D.OverlapCircle(transform.position, OuterRadius);
                if (outerColl != null && outerColl.TryGetComponent(out PlayerController player))
                {
                    OnOuterEnter(player);
                    hasCounterShowed = true;
                }
                else if (hasCounterShowed)
                {
                    hasCounterShowed = false;
                    OnOuterExit();
                }
                
            }

            var innerColl = Physics2D.OverlapCircle(transform.position, InnerRadius);
            if (innerColl != null)
            {
                OnInnerCollision(innerColl.GetComponent<ControllerBase>());
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, InnerRadius);
            Gizmos.DrawWireSphere(transform.position, OuterRadius);
        }

        public virtual void OnOuterEnter(PlayerController player)
        {
            mCounterPlayer = player;

            var panel = UIKit.OpenPanel<CounterPanel>(new CounterPanelData(onCounterSuccess));
            panel.Parent(transform);
            panel.transform.localScale = new Vector3(OuterRadius, OuterRadius, 1f);

            //Debug.Log("tIMW FRR");
            //EffectController.Instance.timescaleEffect();
        }

        private void OnOuterExit()
        {
            mCounterPlayer = null;                  
            UIKit.ClosePanel<CounterPanel>();
        }

        protected virtual void OnCounterSuccess()
        {
           
            EffectController.Instance.screenLowEffect();
        }
    }
}