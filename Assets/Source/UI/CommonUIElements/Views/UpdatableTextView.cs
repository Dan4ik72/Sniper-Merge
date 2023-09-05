using TMPro;
using UnityEngine;

public class UpdatableTextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Init(string defaultText) => _text.text = defaultText;

    public void UpdateText(string newText) => _text.text = newText;
}