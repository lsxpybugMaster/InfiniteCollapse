using System;
using GameMain.Scripts.Defination;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameMain.Scripts.Tools.Level_Manager
{
    [Serializable]
    public class StarConfig
    {
        public StarType type;
        public float appearTime;
        public Transform appearPoint;
        public Transform velocityPoint;

        public Vector2 AppearPosition => appearPoint.position;
        public Vector2 AppearSpeed => velocityPoint.position - appearPoint.position;
    }
}