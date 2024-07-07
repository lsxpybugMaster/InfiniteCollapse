using Assets.GameMain.Scripts.Character.Movement;
using Assets.GameMain.Scripts.Character.Player;
using GameMain.Scripts.Events;
using QFramework;
using UniRx;
using UnityEngine;

namespace Assets.GameMain.Scripts.Models
{
    public class PlayerModel : AbstractModel
    {
        public MovementComp PlayerMovement;
        public PlayerController Controller;

        public ReactiveProperty<int> satelliteAccount = new ReactiveProperty<int>();

        public Transform PlayerTransform => Controller.transform;
        public float CurMagnitudeSpeed => PlayerMovement.CurSpeed;
        public float CurTangentSpeed => PlayerMovement.curForwardSpeed;

        protected override void OnInit()
        {
            satelliteAccount.Subscribe(value =>
            {
                this.SendEvent(new SatelliteAccountChangeEvent() { account = satelliteAccount.Value });
            });
        }

        public void RegisterPlayer(Transform player)
        {
            Controller = player.GetComponent<PlayerController>();
            PlayerMovement = player.GetComponent<MovementComp>();
        }
    }
}