using System.Collections;
using System.Collections.Generic;
using GameMain.Scripts.Controllers.UI.Counter;
using QFramework;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UIKit.OpenPanel<CounterPanel>();
        }
    }
}
