using Assets.GameMain.Scripts.Character.BlackHoleLogic;
using Assets.GameMain.Scripts.Character.Movement;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Looper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.Player
{
    public class PlayerController : MonoBehaviour, ILooper
    {
        private BlackHole mBlackHole;

        private MovementComp mMovementComp;


        public void OnUpdate(float eclapse)
        {
            
        }

        public void OnFixedUpdate()
        {
            
        }

    }
}
