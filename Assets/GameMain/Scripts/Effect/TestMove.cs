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

        // 获取水平和垂直方向上的输入
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 根据输入计算移动向量
        Vector2 moveVector = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // 更新角色的位置
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
