using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GradientText : MonoBehaviour
{
    public TextMeshProUGUI targetText;

    void Start()
    {
        // 确保文本的颜色初始值是透明的
        Color color = targetText.color;
        color.a = 0f;
        targetText.color = color;

        // 使用DOTween使文本在2秒内逐渐浮现
        targetText.DOFade(1f, 2f);
    }
}
