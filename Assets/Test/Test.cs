using System;
using System.Collections;
using System.Collections.Generic;
using GameMain.Scripts.Controllers.UI.Counter;
using QFramework;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, 1f);
    }
}
