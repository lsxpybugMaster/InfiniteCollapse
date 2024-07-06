using Assets.GameMain.Scripts.Looper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<<< HEAD:Assets/GameMain/Scripts/Controllers/Character/BlackHole/BlackHole.cs
using GameMain.Scripts.Controllers;
========
using GameMain.Scripts.Character.Base;
using Sirenix.OdinInspector;
>>>>>>>> 26666dc2c3ec46eac4a0efdb75afb37f83cb6687:Assets/GameMain/Scripts/Controllers/Character/BlackHole/BlackHoleController.cs
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.BlackHoleLogic
{
<<<<<<<< HEAD:Assets/GameMain/Scripts/Controllers/Character/BlackHole/BlackHole.cs
    public class BlackHole : ControllerBase
    {
========
    public class BlackHoleController : MonoBehaviour, ILooper, ICreator
    {
        [InfoBox("该数值乘以距离平方分之一")]
>>>>>>>> 26666dc2c3ec46eac4a0efdb75afb37f83cb6687:Assets/GameMain/Scripts/Controllers/Character/BlackHole/BlackHoleController.cs
        public float AbsorbSpeed;

        public float OuterAccelerateRadius;
        public CircleCollider2D OuterAclColl;
        public CircleCollider2D InnerAbsorbColl;

        private void Start()
        {
            OuterAclColl = transform.Find("Outer").GetComponent<CircleCollider2D>();
            InnerAbsorbColl = transform.Find("Inner").GetComponent<CircleCollider2D>();
        }

<<<<<<<< HEAD:Assets/GameMain/Scripts/Controllers/Character/BlackHole/BlackHole.cs
========
        public float GetAbsorption(Vector2 position)
        {
            var dis = Vector2.Distance(transform.position, position);
            return AbsorbSpeed / (dis * dis);
        }


>>>>>>>> 26666dc2c3ec46eac4a0efdb75afb37f83cb6687:Assets/GameMain/Scripts/Controllers/Character/BlackHole/BlackHoleController.cs
        public void OnUpdate(float eclapse)
        {
            
        }

        public void OnFixedUpdate(float eclapse)
        {
            
        }

<<<<<<<< HEAD:Assets/GameMain/Scripts/Controllers/Character/BlackHole/BlackHole.cs
========
        public void Init(Action<ICreator> initAction)
        {
            initAction?.Invoke(this);
        }
>>>>>>>> 26666dc2c3ec46eac4a0efdb75afb37f83cb6687:Assets/GameMain/Scripts/Controllers/Character/BlackHole/BlackHoleController.cs
    }
}
