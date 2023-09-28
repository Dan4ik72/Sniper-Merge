using UnityEngine;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class MergeOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private ButtonView _mergeButtonView;
    
    private Canvas _canvas;

    private MergeButtonViewPresenter _mergeButtonPresenter;
    private MergeButtonViewModel _mergeButtonModel;

    [Inject]
    public void Construct(LevelWalletService levelWalletService, BulletSpawnService bulletSpawnService)
    {
        _canvas = GetComponent<Canvas>();
        _mergeButtonModel = new MergeButtonViewModel(levelWalletService,bulletSpawnService,15);
        _mergeButtonPresenter = new MergeButtonViewPresenter(_mergeButtonView, _mergeButtonModel);
    }
    
    public void Init()
    {
        _mergeButtonView.Init();
        _mergeButtonPresenter.Init();
    }

    public void Disable()
    {
        _mergeButtonView.Disable();
        _mergeButtonPresenter.Disable();
    }

    public Canvas GetCanvas() => _canvas;
}