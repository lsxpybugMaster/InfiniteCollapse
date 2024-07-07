﻿using System.Collections.Generic;
using System.Linq;
using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Character.Movement;
using Assets.GameMain.Scripts.Looper;
using Assets.GameMain.Scripts.Models;
using GameMain.Scripts.Tools.Level_Manager;
using GameMain.Scripts.Utility;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameMain.Scripts.Controllers
{
    public class LevelManager : ControllerBase
    {
        [TitleGroup("Level Config")]
        public Transform startPoint;
        
        [BoxGroup("Victory Condition")] public float escapeRadius;
        [BoxGroup("Victory Condition")] public float escapeSpeed;
        [BoxGroup("Victory Condition")] public float contrastSpeed;

        [TitleGroup("Stars")] 
        public Transform starsHolder;
        
        [ListDrawerSettings(CustomAddFunction = "ConfigAddFunc", CustomRemoveIndexFunction = "ConfigRemoveFunc")]
        public List<StarConfig> starConfigs = new ();

        private List<ILooper> mainLoop;
        
        private GameObject player;
        private MovementComp movementComp;
        private GameObject blackHole;
        private GameObject frontier;
        
        private List<StarConfig> deleteList = new ();
        private List<StarConfig> starWaitList = new ();
        private float gameTime = 0f;

        public void InitLevel(List<ILooper> gameLoop)
        {
            mainLoop = gameLoop;
            
            blackHole = Resources.Load<GameObject>(PathManager.GetEntityAsset("BlackHole")).Instantiate();
            
            player = Resources.Load<GameObject>(PathManager.GetEntityAsset("Player")).Instantiate();
            movementComp = player.GetComponent<MovementComp>();
            player.Position(GetStartPoint());
            this.GetModel<PlayerModel>().RegisterPlayer(player.transform);
            
            frontier = Resources.Load<GameObject>(PathManager.GetEntityAsset("Frontier")).Instantiate();
            frontier.LocalScale(escapeRadius, escapeRadius, escapeRadius);
            
            starWaitList.AddRange(starConfigs);
            
            this.GetModel<LevelModel>().RegisterLevel(this);
            
            mainLoop.Add(blackHole.GetComponent<ILooper>());
            mainLoop.Add(player.GetComponent<ILooper>());
        }
        
        public override void OnGameInit()
        {
            base.OnGameInit();

            gameTime = 0f;
        }

        public override void OnUpdate(float elapse)
        {
            base.OnUpdate(elapse);

            gameTime += elapse;

            UpdateStarWaitList(elapse);

            UpdateFrontier(elapse);
        }

        private void UpdateStarWaitList(float elapse)
        {
            deleteList.Clear();
            
            foreach (var config in starWaitList)
            {
                if (config.appearTime <= gameTime)
                {
                    var star = Resources.Load<GameObject>(PathManager.GetEntityAsset(config.type.ToString()))
                        .Instantiate(config.AppearPosition, Quaternion.identity);
                    star.GetComponent<Rigidbody2D>().velocity = config.AppearSpeed;
                    deleteList.Add(config);
                }
            }

            foreach (var config in deleteList.Where(config => starWaitList.Contains(config)))
            {
                starWaitList.Remove(config);
            }
        }

        private void UpdateFrontier(float elapse)
        {
            var currentScale = escapeRadius - gameTime * contrastSpeed;
            
            if (currentScale > 0)
            {
                var dis2Frontier =
                    currentScale - Vector2.Distance(player.transform.position, blackHole.transform.position);
                if (dis2Frontier is > 0f and < 1f)
                {
                    if (movementComp.CurSpeed >= escapeSpeed)
                    {
                        Debug.Log("Success");
                    }
                    else
                    {
                        Debug.Log("Fail");
                    }
                }
            }
            
            currentScale = currentScale > 0 ? currentScale : 0f;
            frontier.LocalScale(currentScale, currentScale, currentScale);
            
        }

#if UNITY_EDITOR
        public Vector2 GetStartPoint()
        {
            return startPoint.position;
        }

        private StarConfig ConfigAddFunc()
        {
            var sc = new StarConfig();
            
            var ap = new GameObject("Appear Position").transform;
            ap.Parent(starsHolder);

            var vp = new GameObject("Velocity Point").transform;
            vp.Parent(ap);

            var drawer = vp.gameObject.AddComponent<StartConfigDrawer>();
            drawer.config = sc;
            drawer.fromPoint = ap;
            
            sc.appearPoint = ap;
            sc.velocityPoint = vp;

            return sc;
        }
        
        private void ConfigRemoveFunc(int index)
        {
            var config = starConfigs[index];
            
            DestroyImmediate(config.velocityPoint.gameObject);
            DestroyImmediate(config.appearPoint.gameObject);
            
            starConfigs.RemoveAt(index);
        }  
#endif
    }
}