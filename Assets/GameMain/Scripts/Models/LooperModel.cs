using Assets.GameMain.Scripts.Looper;
using QFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameMain.Scripts.Models
{
    public class LooperModel : AbstractModel
    {
        private ResLoader mResLoader;
        
        private static string looperPath = Path.Combine(Application.dataPath,
            "Resources", "Looper");

        public List<GameObject> Loopers;

        protected override void OnInit()
        {

            Loopers = new();

            Loopers.Add(Resources.Load<GameObject>("Looper/BlackHole"));
            Loopers.Add(Resources.Load<GameObject>("Looper/Player"));
        }
        
    }
}
