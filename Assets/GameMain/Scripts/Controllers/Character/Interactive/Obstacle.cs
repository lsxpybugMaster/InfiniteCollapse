using Assets.GameMain.Scripts.Character.Player;
using UnityEngine;

namespace GameMain.Scripts.Controllers.Character.Interactive
{
    public class Obstacle : InteractiveController
    {
        public override void OnGameInit()
        {
            base.OnGameInit();
            CanCounter = false;
        }

        public override void OnCollision(ControllerBase other)
        {
            var player = other as PlayerController;
            if (!player) return;
            
            player.OnCollisionWithInteractive(controller =>
            {
                Debug.Log($"enter obstacle coll, curspeed {player.mMovementComp.curForwardSpeed}");
                player.mMovementComp.curForwardSpeed -= SpeedDownNumOnCollide;
                Debug.Log($"out obstacle coll, curspeed {player.mMovementComp.curForwardSpeed}");
            });
        }
    }
}