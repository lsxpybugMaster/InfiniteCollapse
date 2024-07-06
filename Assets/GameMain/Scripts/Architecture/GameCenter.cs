using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.GameMain.Scripts.Models;

namespace Assets.GameMain.Scripts.Architecture
{
    public class GameCenter : Architecture<GameCenter>
    {
        protected override void Init()
        {
            this.RegisterModel(new LooperModel());
        }
    }
}
