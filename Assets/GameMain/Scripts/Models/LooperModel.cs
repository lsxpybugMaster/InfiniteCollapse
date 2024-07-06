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
        private static string looperPath = Path.Combine(Application.persistentDataPath, "GameMain",
            "Resources", "Looper");

        public List<ILooper> Loopers;

        protected override void OnInit()
        {
            Loopers = Resources.LoadAll<GameObject>(looperPath).Select(go => go.GetComponent<ILooper>()).ToList();
        }
    }
}
