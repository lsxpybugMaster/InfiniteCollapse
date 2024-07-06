using Assets.GameMain.Scripts.Looper;
using QFramework;
using System.Collections.Generic;
using System.Linq;
using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Models;
using GameMain.Scripts.Utility;
using UnityEngine;

namespace GameMain.Scripts.Game
{
    public class InfiniteCollapseGame : GameBase, IController
    {
        public List<ILooper> Loopers;
        
        public override void Initialize()
        {
            var blackHole = Resources.Load<GameObject>(PathManager.GetEntityAsset("BlackHole")).Instantiate();
            var player = Resources.Load<GameObject>(PathManager.GetEntityAsset("Player")).Instantiate();

            Loopers.Add(blackHole.GetComponent<ILooper>());
            Loopers.Add(player.GetComponent<ILooper>());
        }

        public override void Update(float elapse)
        {
            Loopers.ForEach(x => x.OnUpdate(elapse));
        }

        public override void FixedUpdate(float elapse)
        {
            Loopers.ForEach(x => x.OnFixedUpdate(elapse));
        }

        public IArchitecture GetArchitecture()
        {
            return GameCenter.Interface;
        }
    }
}