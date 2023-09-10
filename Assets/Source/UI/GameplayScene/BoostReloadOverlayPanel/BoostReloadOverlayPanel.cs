using UnityEngine;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class BoostReloadOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private ButtonView _boostReloadButtonView;

    private Canvas _canvas;

    private ButtonViewPresenter _boostReloadButtonPresenter;
    private BoostReloadButtonModel _boostReloadButtonModel;

    [Inject]
    public void Construct(ShootingService shootingService)
    {
        _canvas = GetComponent<Canvas>();
        _boostReloadButtonModel = new BoostReloadButtonModel(shootingService);
        _boostReloadButtonPresenter = new ButtonViewPresenter(_boostReloadButtonView, _boostReloadButtonModel);
    }

    public void Init()
    {
        _boostReloadButtonView.Init();
        _boostReloadButtonPresenter.Init();
    }

    public void Disable()
    {
        _boostReloadButtonView.Disable();
        _boostReloadButtonPresenter.Disable();
    }

    public Canvas GetCanvas() => _canvas;
}
