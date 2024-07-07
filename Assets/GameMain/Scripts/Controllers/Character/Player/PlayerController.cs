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
        private CircleHud mCircleHud;

        public MovementComp mMovementComp { get; private set; }

        public Action<PlayerController> OnPlayerDie;

        private void Awake()
        {
            mMovementComp = GetComponent<MovementComp>();
        }

        private void Start()
        {
            mBlackHole = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<BlackHole>();
            mCircleHud = mBlackHole.GetComponentInChildren<CircleHud>();
        }

        public override void OnUpdate(float eclapse)
        {
            mMovementComp.OnUpdate(eclapse);
            
            UpdateCircle();
        }
        

        public override void OnFixedUpdate(float eclapse)
        {
            
        }

        public void OnDie()
        {
            OnPlayerDie?.Invoke(this);
            Debug.Log("Die");
            
            Destroy(gameObject, 1f);
        }

        public void OnCollisionWithInteractive(Action<PlayerController> action)
        {
            action?.Invoke(this);
        }


        private void UpdateCircle()
        {
            var dis = Vector3.Distance(transform.position, mBlackHole.transform.position);
            mCircleHud.transform.localScale = new Vector3(dis, dis, 1);
        }
    }
}
