using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameMain.Scripts.Looper
{
    public interface ILooper
    {
        void OnUpdate(float eclapse);
        void OnFixedUpdate();
    }
}
