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
    [Header("相机抖动")]
    [SerializeField]
    private MMF_Player screenLowFeedBack;
    [SerializeField]
    private MMF_Player screenMidFeedBack;
    [SerializeField]
    private MMF_Player screenHeavyFeedBack;
    [SerializeField]
    private MMF_Player timescaleFeedBack;

    [Header("子弹时间")]
    [SerializeField]
    private float bulletTimeScale = 0.3f;
    [SerializeField]
    private float bulletTimeDuration = 2f;
    [SerializeField]
    public float transitionDuration = 0.5f; // 时间缩放渐变的持续时间

    private float originalFixedDeltaTime; 
    private bool isBulletTimeActive = false; // 标记子弹时间是否激活
    private Coroutine bulletTimeCoroutine;

    //[Header("一些捆绑的物体")]
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


            // 使用 DoTween 平滑地改变时间缩放
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, bulletTimeScale, transitionDuration)
                .OnUpdate(() => Time.fixedDeltaTime = originalFixedDeltaTime * Time.timeScale)
                .OnComplete(() => bulletTimeCoroutine = StartCoroutine(BulletTimeCountdown()));

            //启动协程，其时间不受子弹时间影响
            //bulletTimeCoroutine = StartCoroutine(BulletTimeCountdown());
        }
    }

    //依据真实时间来计时的协程
    private IEnumerator BulletTimeCountdown()
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + bulletTimeDuration)
        {
            yield return null;
        }
        stopBulletTime();
    }

    //子弹时间开始后自动地去调用，也可以由玩家调用（提前结束子弹时间）
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

            // 使用 DoTween 平滑地恢复时间缩放
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, transitionDuration)
                .OnUpdate(() => Time.fixedDeltaTime = originalFixedDeltaTime * Time.timeScale)
                .OnComplete(() => isBulletTimeActive = false);
        }
    }

    //子弹时间结束后的特效
    public void EffectAfterBulletTime()
    {

    }
}
