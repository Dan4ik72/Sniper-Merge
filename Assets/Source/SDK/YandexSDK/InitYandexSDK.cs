using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;


public class InitYandexSDK : MonoBehaviour
{
    private void Awake()
    {
        WaitForSdkIniting();
    }
    
    private async UniTask WaitForSdkIniting()
    {
        while (YandexGame.SDKEnabled == false)
            await UniTask.WaitForSeconds(0.1f);

        SceneManager.LoadScene(1);
    }
}
