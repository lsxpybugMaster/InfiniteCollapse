using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float moveSpeed;

    //bool ifonce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed * Time.deltaTime, 0, 0);
        //if (transform.position.x > 0 && ifonce)
        //{
        //    //EffectController.Instance.screenEffect();
        //    EffectController.Instance.timescaleEffect();
        //    ifonce = false;
        //}

        // ��ȡˮƽ�ʹ�ֱ�����ϵ�����
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // ������������ƶ�����
        Vector2 moveVector = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // ���½�ɫ��λ��
        transform.Translate(moveVector);

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("start bullet time");
            EffectManager.Instance.startbulletTime();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            EffectManager.Instance.stopBulletTime();
        }
        
    }
    
}
