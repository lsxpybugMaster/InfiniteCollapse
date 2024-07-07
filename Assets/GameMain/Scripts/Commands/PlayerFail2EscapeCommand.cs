using GameMain.Scripts.Events;
using QFramework;

namespace GameMain.Scripts.Commands
{
    public class PlayerFail2EscapeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<PlayerFail2EscapeEvent>();
        }
    }
}