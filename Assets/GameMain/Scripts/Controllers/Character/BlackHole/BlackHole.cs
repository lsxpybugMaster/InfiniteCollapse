using Assets.GameMain.Scripts.Looper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.GameMain.Scripts.Character.Player;
using GameMain.Scripts.Commands;
//using GameMain.Scripts.Character.Base;
using QFramework;
using Sirenix.OdinInspector;
using GameMain.Scripts.Controllers;
using GameMain.Scripts.Controllers.Character.Interactive;
using GameMain.Scripts.Events;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.BlackHoleLogic
{
    public class BlackHole : InteractiveController
    {
        public float AbsorbSpeed;

        public float OuterAccelerateRadius;

        public float OutBoundrySpeed = 100f;
        public float OutBoundryAbsorbTime = 0.5f;


        public float AbsorbMultiplier { get; private set; } = 1f;

        public override void OnGameInit()
        {
            base.OnGameInit();
            this.RegisterEvent<PlayerFail2EscapeEvent>(ctx =>
            {
                StartCoroutine(SetOutBoundryAbosorb());
            }).UnRegisterWhenGameObjectDestroyed(this);
        }

        private float preserveAbosorbSpeed;
        private IEnumerator SetOutBoundryAbosorb()
        {
            preserveAbosorbSpeed = AbsorbSpeed;
            AbsorbSpeed = OutBoundrySpeed;
            yield return new WaitForSeconds(OutBoundryAbsorbTime);
            AbsorbSpeed = preserveAbosorbSpeed;
        } 

        public float GetAbsorption(Vector2 position)
        {
            var dis = Vector2.Distance(transform.position, position);
            return AbsorbSpeed / (dis * dis);
        }

        public override void OnOuterEnter(PlayerController player)
        {
            base.OnOuterEnter(player);
        }

        protected override void OnCounterSuccess()
        {
            base.OnCounterSuccess();
            
            mCounterPlayer.mMovementComp.DashForward();
        }

        public override void OnInnerCollision(ControllerBase other)
        {
            var player = other as PlayerController;
            if (player != null)
            {
                this.SendCommand<PlayerDieCommand>();
            }
        }

        public override void OnGameShutdown()
        {
            base.OnGameShutdown();
            
            StopAllCoroutines();
        }
    }
}
