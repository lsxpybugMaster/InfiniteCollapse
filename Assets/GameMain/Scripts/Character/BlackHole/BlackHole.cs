using Assets.GameMain.Scripts.Looper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.BlackHoleLogic
{
    public class BlackHole : MonoBehaviour, ILooper
    {
        public float AbsorbSpeed;

        public float OuterAccelerateRadius;
        public CircleCollider2D OuterAclColl;
        public CircleCollider2D InnerAbsorbColl;

        private void Start()
        {
            OuterAclColl = transform.Find("Outer").GetComponent<CircleCollider2D>();
            InnerAbsorbColl = transform.Find("Inner").GetComponent<CircleCollider2D>();
        }

        public void OnUpdate(float eclapse)
        {
            
        }

        public void OnFixedUpdate()
        {
            
        }

    }
}
