using Assets.GameMain.Scripts.Models;
using QFramework;

namespace GameMain.Scripts.Controllers.Character.Interactive
{
    public class Satellite : InteractiveController
    {
        protected override void OnCounterSuccess()
        {
            this.GetModel<PlayerModel>().satelliteAccount.Value++;

            DestroySelf();
        }
    }
}