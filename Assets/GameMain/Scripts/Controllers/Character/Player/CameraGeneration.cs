using System;
using Assets.GameMain.Scripts.Character.BlackHoleLogic;
using Cinemachine;
using UnityEngine;

namespace Assets.GameMain.Scripts.Character.Player
{
    public class CameraGeneration : MonoBehaviour
    {
        private CinemachineTargetGroup _targetGroup;
        public float blackHoleWeight = 1f;
        public float blackHoleRadius = 1f;
        
        public float playerWeight = 1f;
        public float playerRadius = 1f;
        
        private void Start()
        {
            var hole = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<BlackHole>();
            _targetGroup = Instantiate(new GameObject("target group")).AddComponent<CinemachineTargetGroup>();
            Camera.main.gameObject.AddComponent<CinemachineBrain>();
            
            _targetGroup.AddMember(hole.transform, blackHoleWeight, blackHoleRadius);
            _targetGroup.AddMember(transform.parent, playerWeight, playerRadius);


            GetComponent<CinemachineVirtualCamera>().LookAt = _targetGroup.transform;
            
        }
    }
}