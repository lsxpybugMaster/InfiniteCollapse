using GameMain.Scripts.Events;
using QFramework;

namespace GameMain.Scripts.Commands
{
    public class PlayerEscapeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<PlayerEscapeEvent>();
        }
    }
}