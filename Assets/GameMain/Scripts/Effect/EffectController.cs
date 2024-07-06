using DG.Tweening.Core.Easing;
using MoreMountains.Feedbacks;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoSingleton<EffectController>
{
    [SerializeField]
    private MMF_Player screenFeedBack;
    [SerializeField]
    private MMF_Player freezeFeedBack;

    public void screenEffect()
    {
        screenFeedBack?.PlayFeedbacks();
    }

    public void freezeEffect() 
    {
        screenFeedBack?.PlayFeedbacks();
    }
}
