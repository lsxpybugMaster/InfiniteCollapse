using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFramework;

namespace Assets.GameMain.Scripts.Looper
{
    public interface ILooper : IController
    {
        public void OnGameInit();

        public void OnUpdate(float elapse);

        public void OnFixedUpdate(float elapse);

        public void OnGameShutdown();
    }
}
