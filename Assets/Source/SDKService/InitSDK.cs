using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitSDK : MonoBehaviour
{
    private void Awake()
    {
#if YANDEX_GAMES
        YandexGamesSdk.CallbackLogging = true;
#endif
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        SceneManager.LoadScene(1);
        yield break;
#endif
#if YANDEX_GAMES
        yield return YandexGamesSdk.Initialize(() => SceneManager.LoadScene(1));
#endif
    }
}
