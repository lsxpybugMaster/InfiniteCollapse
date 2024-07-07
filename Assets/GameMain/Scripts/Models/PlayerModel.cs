using Assets.GameMain.Scripts.Character.Movement;
using Assets.GameMain.Scripts.Character.Player;
using QFramework;
using UnityEngine;

namespace Assets.GameMain.Scripts.Models
{
    public class PlayerModel : AbstractModel
    {
        public MovementComp PlayerMovement;
        public PlayerController Controller;

        public Transform PlayerTransform => Controller.transform;
        public float CurMagtitudeSpeed => PlayerMovement.CurSpeed;
        public float CurTangentSpeed => PlayerMovement.curForwardSpeed;
        
        protected override void OnInit()
        {
            Controller = GameObject.Find("Player").GetComponent<PlayerController>();
            PlayerMovement = Controller.GetComponent<MovementComp>();
        }
    }
}