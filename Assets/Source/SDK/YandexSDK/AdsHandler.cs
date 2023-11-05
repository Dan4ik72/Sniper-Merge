using TMPro;
using UnityEngine;
using YG;

internal class AdsHandler
{
    public static void InvokeInterstitial()
    {
        if (YandexGame.SDKEnabled == false)
            return;

        YandexGame.FullscreenShow();
    }
}
