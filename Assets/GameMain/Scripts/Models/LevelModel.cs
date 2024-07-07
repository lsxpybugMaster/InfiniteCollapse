using GameMain.Scripts.Controllers;
using QFramework;

namespace Assets.GameMain.Scripts.Models
{
    public class LevelModel : AbstractModel
    {
        public float escapeRadius;
        public float escapeSpeed;
        public float contrastSpeed;
        
        protected override void OnInit()
        {
            
        }

        public void RegisterLevel(LevelManager levelManager)
        {
            escapeRadius = levelManager.escapeRadius;
            escapeSpeed = levelManager.escapeSpeed;
            contrastSpeed = levelManager.contrastSpeed;
        }
    }
}