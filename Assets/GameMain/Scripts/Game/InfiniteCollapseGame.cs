﻿using Assets.GameMain.Scripts.Looper;
using QFramework;
using System.Collections.Generic;
using System.Linq;
using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Models;
using GameMain.Scripts.Controllers;
using GameMain.Scripts.Events;
using GameMain.Scripts.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameMain.Scripts.Game
{
    public class InfiniteCollapseGame : GameBase, IController
    {
        private List<ILooper> entityList = new List<ILooper>();
        private List<ILooper> managerList = new List<ILooper>();
        
        public override void Initialize()
        {
            GameOver = false;
            
            var levelManager = Object.FindObjectOfType<LevelManager>();
            
            var effectManager = Resources.Load<GameObject>(PathManager.GetManagerAsset("EffectManager"))
                .Instantiate()
                .Name("EffectManager")
                .GetComponent<EffectManager>();
            
            managerList.Add(levelManager);
            managerList.Add(effectManager);
            
            levelManager.InitLevel(entityList);

            entityList.ForEach(x => x.OnGameInit());
            managerList.ForEach(x => x.OnGameInit());
            
            this.RegisterEvent<PlayerDieEvent>(e =>
            {
                GameOver = true;
            }).UnRegisterWhenGameObjectDestroyed(levelManager);
            
            this.RegisterEvent<PlayerEscapeEvent>(e =>
            {
                GameOver = true;
            }).UnRegisterWhenGameObjectDestroyed(levelManager);
        }

        public override void Update(float elapse)
        {
            entityList.ForEach(x => x.OnUpdate(elapse));
            managerList.ForEach(x => x.OnUpdate(elapse));
        }

        public override void FixedUpdate(float elapse)
        {
            entityList.ForEach(x => x.OnFixedUpdate(elapse));
            managerList.ForEach(x => x.OnFixedUpdate(elapse));
        }
        
        public override void Shutdown()
        {
            base.Shutdown();
            
            entityList.ForEach(x => x.OnGameShutdown());
            managerList.ForEach(x => x.OnGameShutdown());
            
            entityList.Clear();
            managerList.Clear();
        }

        public IArchitecture GetArchitecture()
        {
            return GameCenter.Interface;
        }
    }
}