using UnityEngine.SceneManagement;
using System;

public class SceneTransitionService
{
    private const int InitSceneBuildIndex = 0;
    private const int MainMenuSceneBuildIndex = 1;
    private const int GameSceneBuildIndex = 2;

    public event Action SceneTransiting;
    
    public void TransitToInitScene() => TransitTo(InitSceneBuildIndex);

    public void TransitToMainMenuScene() => TransitTo(MainMenuSceneBuildIndex);

    public void TransitToGameScene() => TransitTo(GameSceneBuildIndex);

    public void ReloadCurrentScene() => TransitTo(SceneManager.GetActiveScene().buildIndex);

    private void TransitTo(int buildIndex)
    {
        SceneTransiting?.Invoke();
        SceneManager.LoadScene(buildIndex);
    }
}

