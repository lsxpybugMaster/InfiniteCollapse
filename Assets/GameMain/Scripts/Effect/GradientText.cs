using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GradientText : MonoBehaviour
{
    TextMeshProUGUI mytext;
    public float elapsetime;

    float timecounter;

    string[] tutorialTexts;
    [SerializeField]
    float[] timeSpand;
    int index = 0;

    void Start()
    {
        tutorialTexts = new string[3];

        timecounter = 0;
        mytext = GetComponent<TextMeshProUGUI>();

        tutorialTexts[0] = "ʹ��AD���й��ƫ��";
        tutorialTexts[1] = "ʹ��WS���м���";
        tutorialTexts[2] = "���úڶ����Լ���";     
        
    }

    private void Update()
    {
        timecounter += Time.deltaTime;
        if( index < tutorialTexts.Length && timecounter > timeSpand[index])
        {
            timecounter = 0;
            mytext.text = tutorialTexts[index];
            index++;
            showTextMesh();
            Invoke(nameof(clearTextMesh), 2f + elapsetime);
        }
    }

    //��չʾ����
    void showTextMesh()
    {
        Color color = mytext.color;
        color.a = 0f;
        mytext.color = color;
        mytext.DOFade(1f, 2f);
    }

    //����ȥ����
    void clearTextMesh()
    {
        mytext.DOFade(0f, 1f);    
    }

}
