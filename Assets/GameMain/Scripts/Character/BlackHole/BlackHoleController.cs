using Assets.GameMain.Scripts.Looper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMain.Scripts.Character.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.BlackHoleLogic
{
    public class BlackHoleController : MonoBehaviour, ILooper, ICreator
    {
        [InfoBox("该数值乘以距离平方分之一")]
        public float AbsorbSpeed;

        public float OuterAccelerateRadius;
        public CircleCollider2D OuterAclColl;
        public CircleCollider2D InnerAbsorbColl;

        private void Start()
        {
            OuterAclColl = transform.Find("Outer").GetComponent<CircleCollider2D>();
            InnerAbsorbColl = transform.Find("Inner").GetComponent<CircleCollider2D>();
        }

        public float GetAbsorption(Vector2 position)
        {
            var dis = Vector2.Distance(transform.position, position);
            return AbsorbSpeed / (dis * dis);
        }


        public void OnUpdate(float eclapse)
        {
            
        }

        public void OnFixedUpdate(float eclapse)
        {
            
        }

        public void Init(Action<ICreator> initAction)
        {
            initAction?.Invoke(this);
        }
    }
}
