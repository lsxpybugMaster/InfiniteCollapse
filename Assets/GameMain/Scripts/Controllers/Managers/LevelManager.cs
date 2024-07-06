using System.Collections.Generic;
using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Looper;
using GameMain.Scripts.Tools.Level_Manager;
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
            
            sc.appearPosition = ap;
            sc.velocityPoint = vp;

            return sc;
        }
        
        private void ConfigRemoveFunc(int index)
        {
            var config = starConfigs[index];
            
            DestroyImmediate(config.velocityPoint.gameObject);
            DestroyImmediate(config.appearPosition.gameObject);
            
            starConfigs.RemoveAt(index);
        }  
#endif
    }
}