using Assets.GameMain.Scripts.Looper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.GameMain.Scripts.Character.Player;
using QFramework;
using Sirenix.OdinInspector;
using GameMain.Scripts.Controllers;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.BlackHoleLogic
{
    public class BlackHole : ControllerBase
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
            OuterAclColl.OnTriggerEnter2DEvent(onOuterCollision).UnRegisterWhenGameObjectDestroyed(this);
            InnerAbsorbColl.OnTriggerEnter2DEvent(onInnerCollision).UnRegisterWhenGameObjectDestroyed(this);
        }

        public float GetAbsorption(Vector2 position)
        {
            var dis = Vector2.Distance(transform.position, position);
            return AbsorbSpeed / (dis * dis);
        }
        

        private void onOuterCollision(Collider2D coll)
        {
            Debug.Log("Coll enter");
            if (coll.transform.TryGetComponent(out PlayerController player))
            {
                player.OnDie();
            }
        }
        
        private void onInnerCollision(Collider2D coll)
        {
            
        }
    }
}
