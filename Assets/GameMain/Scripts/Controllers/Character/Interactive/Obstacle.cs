﻿using Assets.GameMain.Scripts.Character.Player;
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

        public override void OnInnerCollision(ControllerBase other)
        {
            base.OnInnerCollision(other);
        }
    }
}