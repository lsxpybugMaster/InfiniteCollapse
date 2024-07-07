using DG.Tweening;
using DG.Tweening.Core.Easing;
using MoreMountains.Feedbacks;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectController : MonoSingleton<EffectController>
{
    [Header("�������")]
    [SerializeField]
    private MMF_Player screenLowFeedBack;
    [SerializeField]
    private MMF_Player screenMidFeedBack;
    [SerializeField]
    private MMF_Player screenHeavyFeedBack;
    [SerializeField]
    private MMF_Player timescaleFeedBack;

    [Header("�ӵ�ʱ��")]
    [SerializeField]
    private float bulletTimeScale = 0.3f;
    [SerializeField]
    private float bulletTimeDuration = 2f;
    [SerializeField]
    public float transitionDuration = 0.5f; // ʱ�����Ž���ĳ���ʱ��

    private float originalFixedDeltaTime; 
    private bool isBulletTimeActive = false; // ����ӵ�ʱ���Ƿ񼤻�
    private Coroutine bulletTimeCoroutine;

    //[Header("һЩ���������")]
    //[SerializeField]
    //private GameObject TimeScaleControllerPrefab;

    private void Start()
    {   
        originalFixedDeltaTime = Time.fixedDeltaTime;   
        
    }
    public override void OnSingletonInit()
    {
        base.OnSingletonInit();
    }

    public void screenLowEffect()
    {
        screenLowFeedBack?.PlayFeedbacks();
    }

    public void screenMidEffect()
    {
        screenMidFeedBack?.PlayFeedbacks();
    }

    public void screenHighEffect()
    {
        screenHeavyFeedBack?.PlayFeedbacks();
    }

    public void timescaleEffect() 
    {
        timescaleFeedBack?.PlayFeedbacks();
    }

    public void startbulletTime()
    {
        if (!isBulletTimeActive)
        {
            isBulletTimeActive = true;

            //Time.timeScale = bulletTimeScale;
            //Time.fixedDeltaTime = originalFixedDeltaTime * bulletTimeScale;


            // ʹ�� DoTween ƽ���ظı�ʱ������
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, bulletTimeScale, transitionDuration)
                .OnUpdate(() => Time.fixedDeltaTime = originalFixedDeltaTime * Time.timeScale)
                .OnComplete(() => bulletTimeCoroutine = StartCoroutine(BulletTimeCountdown()));

            //����Э�̣���ʱ�䲻���ӵ�ʱ��Ӱ��
            //bulletTimeCoroutine = StartCoroutine(BulletTimeCountdown());
        }
    }

    //������ʵʱ������ʱ��Э��
    private IEnumerator BulletTimeCountdown()
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + bulletTimeDuration)
        {
            yield return null;
        }
        stopBulletTime();
    }

    //�ӵ�ʱ�俪ʼ���Զ���ȥ���ã�Ҳ��������ҵ��ã���ǰ�����ӵ�ʱ�䣩
    public void stopBulletTime()
    {
        if (isBulletTimeActive)
        {
            //Time.timeScale = 1f;
            //Time.fixedDeltaTime = originalFixedDeltaTime;
            //isBulletTimeActive = false;

            
            if (bulletTimeCoroutine != null)
            {
                StopCoroutine(bulletTimeCoroutine);
            }

            // ʹ�� DoTween ƽ���ػָ�ʱ������
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, transitionDuration)
                .OnUpdate(() => Time.fixedDeltaTime = originalFixedDeltaTime * Time.timeScale)
                .OnComplete(() => isBulletTimeActive = false);
        }
    }

    //�ӵ�ʱ����������Ч
    public void EffectAfterBulletTime()
    {

    }
}
