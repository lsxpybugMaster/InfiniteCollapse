using Assets.GameMain.Scripts.Looper;
using QFramework;
using System.Collections.Generic;
using System.Linq;
using Assets.GameMain.Scripts.Architecture;
using Assets.GameMain.Scripts.Logic.Input;
using Assets.GameMain.Scripts.Models;
using UnityEngine;

namespace GameMain.Scripts.Game
{
    public class InfiniteCollapse : GameBase, IController
    {
        public List<ILooper> Loopers;
        private LooperModel _looperModel;
        
        public override void Initialize()
        {
            _looperModel = this.GetModel<LooperModel>();

            var gos = _looperModel.Loopers;
            gos.ForEach(x => x.Instantiate());
            Loopers = gos.Select(x => x.GetComponent<ILooper>()).ToList();
        }

        public override void Update(float elapse)
        {
            Loopers.ForEach(x => x.OnUpdate(elapse));
        }

        public override void FixedUpdate(float elapse)
        {
            base.FixedUpdate(elapse);
        }

        public IArchitecture GetArchitecture()
        {
            return GameCenter.Interface;
        }
    }
}