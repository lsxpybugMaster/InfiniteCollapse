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
        // ȷ���ı�����ɫ��ʼֵ��͸����
        Color color = targetText.color;
        color.a = 0f;
        targetText.color = color;

        // ʹ��DOTweenʹ�ı���2�����𽥸���
        targetText.DOFade(1f, 2f);
    }
}
