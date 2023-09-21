using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextView : MonoBehaviour
{
    private TMP_Text _text;
    private string _prefix;

    public void Init()
    {
        _text = GetComponent<TMP_Text>();
        _prefix = _text.text;
    }

    public void RenderStandart<T>(T value)
    {
        _text.text = _prefix + value.ToString();
    }

    //public void RenderLocalization<T>(T value)
    //{
    //    _text.text = _prefix + LeanLocalization.GetTranslationText(value.ToString());
    //}
}
