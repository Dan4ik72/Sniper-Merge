using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class AdsHandler
{
    private static Action OnReward;
    
    public static void InvokeInterstitial()
    {
        if (YandexGame.SDKEnabled == false)
            return;

        YandexGame.FullscreenShow();
    }

    public static void InvokeReward(Action onReward)
    {
        OnReward = onReward;
        YandexGame.RewVideoShow(0);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        YandexGame.CloseVideoEvent += OnRewardedComplete;
    }

    private static void OnRewardedComplete()
    {
        OnReward?.Invoke();
        YandexGame.CloseVideoEvent -= OnRewardedComplete;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
