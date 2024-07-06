using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Looper;
using QFramework;
using UnityEngine;

namespace GameMain.Scripts.Controllers
{
    public class LevelManager : ControllerBase
    {
        public Transform startPoint;

        public Vector2 GetStartPoint()
        {
            return startPoint.position;
        }
    }
}