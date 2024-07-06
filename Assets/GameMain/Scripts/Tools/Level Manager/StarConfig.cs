using System;
using GameMain.Scripts.Defination;
using UnityEngine;

namespace GameMain.Scripts.Tools.Level_Manager
{
    [Serializable]
    public class StarConfig
    {
        public StarType type;
        public float appearTime;
        public Transform appearPosition;
        public Transform originalSpeed;
    }
}