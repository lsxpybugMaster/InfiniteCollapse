using Assets.GameMain.Scripts.Looper;
using QFramework;
using System.Collections.Generic;
using System.Linq;
using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Models;
using GameMain.Scripts.Controllers;
using GameMain.Scripts.Utility;
using UnityEngine;

namespace GameMain.Scripts.Game
{
    public class InfiniteCollapseGame : GameBase, IController
    {
        public List<ILooper> Loopers = new List<ILooper>();
        
        public override void Initialize()
        {
            var levelManager = Object.FindObjectOfType<LevelManager>();
            
            Loopers.Add(levelManager);
            
            levelManager.InitLevel(Loopers);

            Loopers.ForEach(x => x.OnGameInit());
        }

        public override void Update(float elapse)
        {
            Loopers.ForEach(x => x.OnUpdate(elapse));
        }

        public override void FixedUpdate(float elapse)
        {
            Loopers.ForEach(x => x.OnFixedUpdate(elapse));
        }
        
        public override void Shutdown()
        {
            base.Shutdown();
            
            Loopers.ForEach(x => x.OnGameShutdown());
        }

        public IArchitecture GetArchitecture()
        {
            return GameCenter.Interface;
        }
    }
}