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

    void Start()
    {
        mat = GetComponent<TrailRenderer>().materials[0];
        tr = GetComponent<TrailRenderer>();
        tr.materials[0] = mat;
    }


    void Update()
    {
        //获取当前玩家速度和通关阈值速度

        //currentSpeed = 玩家当前速度;
        //threshold = 当前关卡通关阈值速度;
        //以下的功能是：玩家的速度大于阈值就改变尾迹颜色   应该不需要修改，把上面的两行获取速度的代码写一下就可以了
        if (currentSpeed>=threshholdSpeed)
        {
            tr.materials[0].SetColor("_Color1", highSpeedColor);
        }
        else
        {
            tr.materials[0].SetColor("_Color1", lowSpeedColor);
        }
    }
}
