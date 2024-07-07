using Assets.GameMain.Scripts.Character.Player;

namespace GameMain.Scripts.Controllers.Character.Interactive
{
    public class Meteor : InteractiveController
    {
        public override void OnOuterEnter(PlayerController player)
        {
            base.OnOuterEnter(player);
        }

        public override void OnInnerCollision(ControllerBase other)
        {
            base.OnInnerCollision(other);
            if (other is PlayerController)
                DestroySelf();

            if (other is Stellar)
            {
                (other as Stellar).IncreaseMass();
            }
        }

        public override void DestroySelf()
        {
            
            
            base.DestroySelf();
        }
    }
}