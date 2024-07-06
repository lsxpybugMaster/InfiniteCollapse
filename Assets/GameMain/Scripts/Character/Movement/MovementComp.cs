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

        public Vector2 CurVelocity { get; private set; }

        private Vector3 mNormalVec;
        private BlackHole mBlackHole;

        private void Start()
        {
            mBlackHole = GameObject.Find("BlackHole").GetComponent<BlackHole>();
        }

        public void OnUpdate(float eclapse)
        {
            mNormalVec = transform.position - mBlackHole.transform.position;
            mNormalVec.Normalize();

            if (InputManager.Instance.MovementInput.magnitude > 0.05f)
            {
                var angle = Vector3.Angle(Vector2.up, mNormalVec);
                var movement = InputManager.Instance.MovementInput;

                var normalDir = mNormalVec * movement.y;
                var tangentDir = Vector3.ProjectOnPlane(normalDir, Vector3.forward) * movement.x;

                transform.position += (normalDir + tangentDir) * Time.deltaTime;

                Debug.Log($"move update:  normal -- {mNormalVec}  movement: {normalDir + tangentDir}");
            }
        }

        public void OnFixedUpdate()
        {
            throw new NotImplementedException();
        }

    }
}
