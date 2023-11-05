using YG;
using Lean.Localization;
using System.Collections.Generic;
using VContainer;
using UnityEngine;

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
        Set(YandexGame.EnvironmentData.language);
    }

    private void Set(string name)
    {
        Debug.Log(111);
        if (_languages.ContainsKey(name))
            _leanLocalization.SetCurrentLanguage(_languages[name]);
    }
}
