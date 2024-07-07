using Assets.GameMain.Scripts.Character.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColorControl : MonoBehaviour
{
    public Material mat;
    public Color lowSpeedColor;
    public Color highSpeedColor;
    private float threshholdSpeed;
    private float currentSpeed;
    private TrailRenderer tr;
    //public float test;

    [SerializeField]
    private MovementComp playerMovementComp;

    void Start()
    {
        mat = GetComponent<TrailRenderer>().materials[0];
        tr = GetComponent<TrailRenderer>();
        tr.materials[0] = mat;
    }


    void Update()
    {
        //获取当前玩家速度和通关阈值速度
        currentSpeed = playerMovementComp.CurSpeed; 
        threshholdSpeed = 10f;
        //以下的功能是：玩家的速度大于阈值就改变尾迹颜色   应该不需要修改，把上面的两行获取速度的代码写一下就可以了
        if (currentSpeed>=threshholdSpeed)
        {
            tr.materials[0].SetColor("_Color1", highSpeedColor);
        }
        else
        {
            //Debug.Log("changeColor");
            tr.materials[0].SetColor("_Color1", lowSpeedColor);
        }
    }
}
