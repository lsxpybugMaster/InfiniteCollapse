using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GradientText : MonoBehaviour
{
    TextMeshProUGUI mytext;
    public float elapsetime;

    void Start()
    {
        mytext = GetComponent<TextMeshProUGUI>();
        showTextMesh();
        Invoke(nameof(clearTextMesh),elapsetime);
    }

    //逐渐展示文字
    void showTextMesh()
    {
        Color color = mytext.color;
        color.a = 0f;
        mytext.color = color;

      
        mytext.DOFade(1f, 3f);
    }

    //逐渐消去文字
    void clearTextMesh()
    {
        mytext.DOFade(0f, 1.5f);
        Invoke(nameof(Destroy), 3f);
    }

    void Destroyme()
    {
        Destroy(gameObject);
    }
}
