using Assets.GameMain.Scripts.Character.BlackHoleLogic;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Looper;
using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMain.Scripts.Controllers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.GameMain.Scripts.Character.Movement
{
    public class MovementComp : ControllerBase
    {
        public float MaxSpeed;

        public float Acceleration;

        public float curForwardSpeed;

        public float NormalSpeed;
        
        public Vector2 CurVelocity { get; private set; }

        private Vector3 mNormalVec;
        private BlackHole mBlackHole;


        private InputManager mInputManager;

        private void Start()
        {
            mBlackHole = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<BlackHole>();
            mInputManager = InputManager.Instance;
        }

        public void OnUpdate(float eclapse)
        {
            if (InputManager.Instance.MovementInput.magnitude > 0.05f)
            {
                Move(eclapse);
            }
        }

        private void Move(float eclapse)
        {
            mNormalVec = transform.position - mBlackHole.transform.position;
            
            var tangentDir = Vector3.Cross(mNormalVec, Vector3.forward);
            var normalDir = mNormalVec.normalized * -mInputManager.MovementInput.x;

            curForwardSpeed += mInputManager.MovementInput.y * Acceleration * eclapse;
            curForwardSpeed = Mathf.Clamp(curForwardSpeed, 0f, MaxSpeed);
            
            var movement = tangentDir.normalized * curForwardSpeed + normalDir * NormalSpeed;
            

            Debug.DrawLine(transform.position, transform.position + tangentDir * curForwardSpeed, Color.red);
            transform.Translate(movement * eclapse);
        }

        public void OnFixedUpdate(float eclapse)
        {
            
        }
        
    }
}
