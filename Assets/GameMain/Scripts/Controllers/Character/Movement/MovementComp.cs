using Assets.GameMain.Scripts.Character.BlackHoleLogic;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Looper;
using QFramework;
using System;
using System.Collections;
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
        public float curNormalSpeed;

        public float DashTimeFromBlackHole = 0.5f;
        public float DashSpeedIncrease = 5f;
        
        public float CurSpeed { get; private set; }

        public float NormalSpeed;
        
        public Vector2 CurVelocity { get; private set; }

        private Vector3 mNormalVec;
        private BlackHole _mBlackHoleController;


        private InputManager mInputManager;

        private void Start()
        {
            _mBlackHoleController = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<BlackHole>();
            mInputManager = InputManager.Instance;
        }

        public override void OnUpdate(float eclapse)
        {
            if (!isCounterBlackHole)
            {
                Move(eclapse);
            }
        }

        private void Move(float eclapse)
        {
            mNormalVec = transform.position - _mBlackHoleController.transform.position;
            
            var tangentDir = Vector3.Cross(mNormalVec, Vector3.forward);
            var normalDir = mNormalVec.normalized * -mInputManager.MovementInput.x;

            curForwardSpeed += mInputManager.MovementInput.y * Acceleration * eclapse;
            curForwardSpeed = Mathf.Clamp(curForwardSpeed, 0f, MaxSpeed);
            
            var movement = tangentDir.normalized * curForwardSpeed + normalDir * NormalSpeed + GetAbsorption();

            CurSpeed = movement.magnitude;

            Debug.DrawLine(transform.position, transform.position + tangentDir * curForwardSpeed, Color.red);
            transform.Translate(movement * eclapse);
        }

        private bool isCounterBlackHole = false;
        public void DashForward()
        {
            isCounterBlackHole = true;
            StartCoroutine(DashForwardCoroutine(0.5f));
        }

        public void StopDash()
        {
            StopAllCoroutines();
        }

        IEnumerator DashForwardCoroutine(float time)
        {
            var tangentDir = Vector3.Cross(mNormalVec, Vector3.forward);
            curForwardSpeed += DashSpeedIncrease;
            MaxSpeed += DashSpeedIncrease;
            while (time > 0)
            {
                time -= Time.deltaTime;
                transform.Translate(tangentDir * curForwardSpeed * Time.deltaTime);
                yield return null;
            }

            isCounterBlackHole = false;
        }

        private Vector3 GetAbsorption()
        {
            var absorption = _mBlackHoleController.GetAbsorption(transform.position);
            return -mNormalVec * absorption;
        }

        public void DecreaseForwardSpeed(float descreament)
        {
            curForwardSpeed -= descreament;
        }

        public void IncreaseForwardSpeed(float increase)
        {
            MaxSpeed += increase;
            curForwardSpeed += increase;
        }
    }
}
