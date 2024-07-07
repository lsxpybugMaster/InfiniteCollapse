using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.GameMain.Scripts.Character.Player;
using GameMain.Scripts.Utility;
using UnityEngine;

namespace Assets.GameMain.Scripts.Logic.Input
{
    public class InputManager : MonoSingleton<InputManager>
    {
        private InputConfig inputActions;

        public Vector2 MovementInput { get; private set; }

        public event Action OnCounterInput;
        
        public bool cooldown = false;

        public override void OnSingletonInit()
        {
            inputActions = new InputConfig();

            inputActions.Player.Movement.performed += ctx => MovementInput = ctx.ReadValue<Vector2>();
            inputActions.Player.Movement.canceled += ctx => MovementInput = Vector2.zero;

            inputActions.Player.Interact.started += ctx =>
            {
                if (cooldown)
                {
                    OnCounterInput?.Invoke();
                }
                cooldown = false;
                Destroy(qteHint);
                qteHint = null;
                StartCoroutine(cooldowncoro());
            };

            inputActions.Enable();

        }


        private PlayerController player;
        private void Start()
        {
            player = GameObject.FindObjectOfType<PlayerController>();
        }


        private GameObject qteHint;
        IEnumerator cooldowncoro()
        {
            yield return new WaitForSeconds(1f);
            cooldown = true;
            qteHint = Resources.Load<GameObject>(PathManager.GetEntityAsset("QTENotice")).Instantiate();
            qteHint.Parent(player);
            qteHint.transform.localPosition = Vector3.zero;
            
        }
    }
}
