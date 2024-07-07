using Assets.GameMain.Scripts.Character.Movement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedShow : MonoBehaviour
{
    TextMeshProUGUI speedText;
    public MovementComp playerMove;

    // Start is called before the first frame update
    void Start()
    {
        speedText  = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed: " + playerMove.CurSpeed;
    }
}
