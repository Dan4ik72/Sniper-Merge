using UnityEngine;
using YG;

internal static class YandexGameInterstitialHandler
{
    public static void InvokeInterstitial()
    {
        if (YandexGame.SDKEnabled == false)
            return;

        YandexGame.FullscreenShow();
    }
}
