using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameMain.Scripts.Logic.Input
{
    public class InputManager : MonoSingleton<InputManager>
    {
        private InputConfig inputActions;

        public Vector2 MovementInput { get; private set; }

        public override void OnSingletonInit()
        {
            inputActions = new InputConfig();

            inputActions.Player.Movement.performed += ctx => MovementInput = ctx.ReadValue<Vector2>();
            inputActions.Player.Movement.canceled += ctx => MovementInput = Vector2.zero;

            inputActions.Enable();

        }
    }
}
