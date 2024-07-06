using Assets.GameMain.Scripts.Character.BlackHoleLogic;
using Assets.GameMain.Scripts.Character.Movement;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Looper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMain.Scripts.Controllers;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.Player
{
    public class PlayerController : ControllerBase
    {
        private BlackHole mBlackHole;

        private MovementComp mMovementComp;


        private void Awake()
        {
            mMovementComp = GetComponent<MovementComp>();
        }

        public void OnUpdate(float eclapse)
        {
        }

        private void Update()
        {
            mMovementComp.OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            mMovementComp.OnFixedUpdate(Time.fixedDeltaTime);
        }

        public void OnFixedUpdate(float eclapse)
        {
            
        }

    }
}
