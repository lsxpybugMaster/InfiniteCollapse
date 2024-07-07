using Assets.GameMain.Scripts.Character.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    Image img;
    [SerializeField]
    private MovementComp playerMovementComp;

    public float maxAmount = 1;
    public float maxSpeed = 30;
    public float speed = 0;

    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerMovementComp.CurSpeed;
        if(speed > maxSpeed)
            speed = maxSpeed;
        Debug.Log($"speed : {speed} maxspeed : {maxSpeed} fill : {(speed / maxSpeed) * maxAmount}");
        img.fillAmount = (speed / maxSpeed) * maxAmount;
    }
}
