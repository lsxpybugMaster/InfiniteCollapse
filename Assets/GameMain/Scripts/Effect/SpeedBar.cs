using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    Image img;

    public float maxAmount = 1;
    public float maxSpeed = 100;
    public float speed = 100;

    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = (speed / maxSpeed) * maxAmount;
    }
}
