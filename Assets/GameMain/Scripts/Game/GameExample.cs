using Assets.GameMain.Scripts.Looper;
using QFramework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameMain.Scripts.Game
{
    public class GameLoopMain : GameBase, IController
    {
        public List<ILooper> Loopers;


        public override void Initialize()
        {
            //Loopers = 
        }

        public override void Update(float elapse)
        {
            Loopers.ForEach(x => x.OnUpdate(elapse));
        }

        public IArchitecture GetArchitecture()
        {
            throw new System.NotImplementedException();
        }
    }
}