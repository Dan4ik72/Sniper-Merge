using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LocalizationHandler : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    [SerializeField] private string _tr;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();

        ProcessLocalization();
    }

    private void ProcessLocalization()
    {
        var currentLanguage = YandexGame.EnvironmentData.language;

        switch (currentLanguage)
        {
            case "ru":
                _text.text = _ru;
                break;
            
            case "en":
                _text.text = _en;
                break;
            
            case "tr":
                _text.text = _tr;
                break;
            
            default:
                _text.text = _en;
                break;
        }
    }
}
