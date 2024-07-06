using Assets.GameMain.Scripts.Character.Player;
using UnityEngine;

namespace GameMain.Scripts.Controllers.Character.Interactive
{
    public class Debris : InteractiveController
    {
        public override void OnGameInit()
        {
            base.OnGameInit();
            CanCounter = false;
        }
        
    }
}