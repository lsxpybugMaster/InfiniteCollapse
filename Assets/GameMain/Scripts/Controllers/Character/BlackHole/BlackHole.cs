using Assets.GameMain.Scripts.Looper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.GameMain.Scripts.Character.Player;
//using GameMain.Scripts.Character.Base;
using QFramework;
using Sirenix.OdinInspector;
using GameMain.Scripts.Controllers;
using GameMain.Scripts.Controllers.Character.Interactive;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.BlackHoleLogic
{
    public class BlackHole : InteractiveController
    {
        public float AbsorbSpeed;

        public float OuterAccelerateRadius;

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
            
        }

        public override void OnInnerCollision(ControllerBase other)
        {
            var player = other as PlayerController;
            if (player != null)
            {
                player.OnDie();
            }
        }
    }
}
