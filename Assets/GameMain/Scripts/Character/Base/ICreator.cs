using System;

namespace GameMain.Scripts.Character.Base
{
    public interface ICreator
    {
        void Init(Action<ICreator> initAction);
    }
}