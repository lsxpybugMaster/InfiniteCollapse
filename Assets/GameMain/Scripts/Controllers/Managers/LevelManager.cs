using System.Collections.Generic;
using System.Linq;
using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Looper;
using GameMain.Scripts.Tools.Level_Manager;
using GameMain.Scripts.Utility;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameMain.Scripts.Controllers
{
    public class LevelManager : ControllerBase
    {
        [TitleGroup("Start Point")]
        public Transform startPoint;

        [TitleGroup("Stars")] 
        public Transform starsHolder;
        
        [ListDrawerSettings(CustomAddFunction = "ConfigAddFunc", CustomRemoveIndexFunction = "ConfigRemoveFunc")]
        public List<StarConfig> starConfigs = new List<StarConfig>();

        private List<StarConfig> deleteList = new();
        private List<StarConfig> starWaitList = new List<StarConfig>();
        private float gameTime = 0f;

        public override void OnGameInit()
        {
            base.OnGameInit();

            gameTime = 0f;
            
            starWaitList.AddRange(starConfigs);
        }

        public override void OnUpdate(float elapse)
        {
            base.OnUpdate(elapse);

            gameTime += elapse;

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