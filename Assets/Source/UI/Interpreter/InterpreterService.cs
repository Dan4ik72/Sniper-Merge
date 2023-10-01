//using Agava.YandexGames;
using Lean.Localization;
using System.Collections.Generic;
using VContainer;

public class InterpreterService
{
    private LeanLocalization _leanLocalization;
    private Dictionary<string, string> _languages = new Dictionary<string, string>();

    [Inject]
    public InterpreterService(LeanLocalization leanLanguage)
    {
        _leanLocalization = leanLanguage;
        _languages.Add("en", "English");
        _languages.Add("ru", "Russian");
        _languages.Add("tr", "Turkish");

#if !UNITY_WEBGL || UNITY_EDITOR
        Set("ru");
        return;
#endif
#if YANDEX_GAMES
        Set("ru");
        //Set(YandexGamesSdk.Environment.i18n.lang);
#endif
    }

    private void Set(string name)
    {
        if (_languages.ContainsKey(name))
            _leanLocalization.SetCurrentLanguage(_languages[name]);
    }
}
