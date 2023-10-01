using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class MainMenuTrainingPanel : MonoBehaviour, IUiPanel
{
    private Canvas _canvas;

    [SerializeField] private List<Canvas> _pointers;
    [SerializeField] private List<string> _ruHints;
    [SerializeField] private List<string> _enHints;
    [SerializeField] private List<string> _trHints;

    [SerializeField] private ButtonView _buttonView;

    private int _currentStep = 0;
    
    public void Init()
    {
        _canvas = GetComponent<Canvas>();

        _buttonView.Clicked += UpdateStep;
    }

    public void StartTraining()
    {
        UpdateStep();
    }
    
    public void Disable()
    {
        _buttonView.Clicked -= Disable;
    }

    private void UpdateStep()
    {
        //localizate
        _buttonView.SetButtonText(_ruHints[_currentStep]);
        _pointers.ForEach(canvas => canvas.enabled = false);
        _pointers[_currentStep].enabled = true;
        _currentStep++;
    }
    
    public Canvas GetCanvas() => _canvas;
}
