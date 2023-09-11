using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class UIGameEndingPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private TMP_Text _moneyReceived;
    [SerializeField] private TMP_Text _enemiesKilled;
    
    private Canvas _canvas;

    public void Init()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void SetUiPanelParameters(int moneyReceived, int enemyKilled)
    {
        _moneyReceived.text = moneyReceived.ToString();
        _enemiesKilled.text = enemyKilled.ToString();
    }

    public void Disable()
    {

    }

    public Canvas GetCanvas() => _canvas;
}
