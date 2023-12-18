using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YG;

public class Tutorial : MonoBehaviour
{
    private const string TutorialSaveKey = "TutorialCompleted";

    [FormerlySerializedAs("_tutorialDesktop")] [SerializeField] private Button _tutorial;
    
    private float _volume; 
    
    private void Start()
    {
        if(PlayerPrefs.HasKey(TutorialSaveKey))
            return;
        
        InvokeTutorial();
        
        _tutorial.onClick.AddListener(CloseTutorial);
    }

    private void InvokeTutorial()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        
        _volume = AudioListener.volume;
        AudioListener.volume = 0;

        _tutorial.gameObject.SetActive(true);
    }

    private void CloseTutorial()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        
        AudioListener.volume = _volume;

        PlayerPrefs.SetInt(TutorialSaveKey, 1);
        
        _tutorial.onClick.RemoveListener(CloseTutorial);
        _tutorial.gameObject.SetActive(false);
    }
}
