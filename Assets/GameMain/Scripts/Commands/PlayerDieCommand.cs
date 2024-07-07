using GameMain.Scripts.Events;
using QFramework;

namespace GameMain.Scripts.Commands
{
    public class PlayerDieCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<PlayerDieEvent>();
        }
    }
}