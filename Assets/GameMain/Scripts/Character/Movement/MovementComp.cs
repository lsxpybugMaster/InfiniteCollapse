using Assets.GameMain.Scripts.Character.BlackHoleLogic;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Looper;
using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.Movement
{
    public class MovementComp : MonoBehaviour, ILooper
    {
        public float MaxVelocitySpeed;

        public float curForwardSpeed;
        
        public Vector2 CurVelocity { get; private set; }

        private Vector3 mNormalVec;
        private BlackHole mBlackHole;

        private void Start()
        {
            mBlackHole = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<BlackHole>();
        }

        public void OnUpdate(float eclapse)
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward, Color.blue);
            
            Debug.DrawLine(transform.position, transform.position + Vector3.forward,
                Color.green);
            
            var tangentDir = Vector3.Cross(mNormalVec, Vector3.forward);

            Debug.DrawLine(transform.position, transform.position + transform.up,
                Color.red);
            
            if (InputManager.Instance.MovementInput.magnitude > 0.05f)
            {
                Move(eclapse);
            }
        }

        private void Move(float eclapse)
        {
            mNormalVec = transform.position - mBlackHole.transform.position;
            
            var tangentDir = Vector3.Cross(mNormalVec, Vector3.forward);
            var targetDir = transform.position + tangentDir.normalized;

            var angle = Vector3.SignedAngle(tangentDir.normalized, Vector3.up,  Vector3.forward);
            Debug.Log($"angle: {angle}");

            Debug.DrawLine(transform.position, transform.position + tangentDir * curForwardSpeed, Color.red);
            transform.Translate(tangentDir.normalized * curForwardSpeed * eclapse);
        }   

        public void OnFixedUpdate(float eclapse)
        {
            
        }
        
    }
}
