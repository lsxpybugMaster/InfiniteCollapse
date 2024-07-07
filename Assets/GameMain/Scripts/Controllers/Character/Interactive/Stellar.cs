using Sirenix.OdinInspector;
using UnityEngine.Serialization;

namespace GameMain.Scripts.Controllers.Character.Interactive
{
    public class Stellar : InteractiveController
    {

        [Title("Stellar Config")]
        [InfoBox("玩家成功qte后增加速度, Mass * 该值")]
        public float CounterIncreaseMultiplier = 1.5f;
        public float MassIncreaseAmount = 2f;
        
        public void IncreaseMass()
        {
            Mass += MassIncreaseAmount;
        }

        protected override void OnCounterSuccess()
        {
            base.OnCounterSuccess();
            
            mCounterPlayer.mMovementComp.IncreaseForwardSpeed(Mass);
        }
    }
}