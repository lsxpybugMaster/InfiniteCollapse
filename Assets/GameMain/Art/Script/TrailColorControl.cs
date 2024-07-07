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
        //��ȡ��ǰ����ٶȺ�ͨ����ֵ�ٶ�
        currentSpeed = playerMovementComp.CurSpeed; 
        threshholdSpeed = 10f;
        //���µĹ����ǣ���ҵ��ٶȴ�����ֵ�͸ı�β����ɫ   Ӧ�ò���Ҫ�޸ģ�����������л�ȡ�ٶȵĴ���дһ�¾Ϳ�����
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
