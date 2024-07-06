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
        
        [ListDrawerSettings(CustomAddFunction = "ConfigAddFunc")]
        public List<StarConfig> startConfigs = new List<StarConfig>();

        public Vector2 GetStartPoint()
        {
            return startPoint.position;
        }

        private StarConfig ConfigAddFunc()
        {
            var sc = new StarConfig();
            
            var ap = new GameObject("Appear Position").transform;
            ap.Parent(starsHolder);

            var os = new GameObject("Original Speed").transform;
            os.Parent(ap);

            var drawer = ap.gameObject.AddComponent<StartConfigDrawer>();
            drawer.config = sc;
            
            sc.appearPosition = ap;
            sc.originalSpeed = os;

            return sc;
        }
    }
}