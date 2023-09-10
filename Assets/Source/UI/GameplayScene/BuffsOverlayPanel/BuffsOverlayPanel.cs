using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class BuffsOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private BuffButtonView _damageBuffButtonView;
    [SerializeField] private BuffButtonView _shootingSpeedBuffButtonView;

    private List<(BuffButtonViewModel, BuffButtonViewPresenter, BuffButtonView)> _buffMVPs = new();

    private BuffProcessingService _buffProcessingService;
    private LevelWalletService _levelWalletService;
    private BuffsContainerService _buffsContainerService;
    
    private Canvas _canvas;

    [Inject]
    public void Construct(BuffProcessingService buffProcessingService, LevelWalletService levelWalletService,
        BuffsContainerService buffContainerService)
    {
        _canvas = GetComponent<Canvas>();

        _buffsContainerService = buffContainerService;
        _buffProcessingService = buffProcessingService;
        _levelWalletService = levelWalletService;

        _buffMVPs.Add(ConstructBuffMvp(_buffsContainerService.GetBuff<DamageBuff>(), _damageBuffButtonView));
        _buffMVPs.Add(ConstructBuffMvp(_buffsContainerService.GetBuff<ShootingSpeedBuff>(), _shootingSpeedBuffButtonView));
    }

    public void Init()
    {
        foreach(var buffMVP in _buffMVPs)
            InitBuffMvp(buffMVP);
    }

    public void Disable()
    {
        foreach(var buffMVP in _buffMVPs)
            DisableBuffMvp(buffMVP);
    }

    public Canvas GetCanvas() => _canvas;

    private (BuffButtonViewModel, BuffButtonViewPresenter, BuffButtonView) ConstructBuffMvp(Buff buff, BuffButtonView buffButtonView)
    {
        var buffButtonViewModel = new BuffButtonViewModel(buff, _buffProcessingService, _levelWalletService);
        var buffButtonPresenter = new BuffButtonViewPresenter(buffButtonViewModel, buffButtonView);

        return (buffButtonViewModel, buffButtonPresenter, buffButtonView);
    }

    private void InitBuffMvp((BuffButtonViewModel, BuffButtonViewPresenter, BuffButtonView) mvp)
    {
        mvp.Item1.Init();
        mvp.Item2.Init();
        mvp.Item3.Init();
    }

    private void DisableBuffMvp((BuffButtonViewModel, BuffButtonViewPresenter, BuffButtonView) mvp)
    {
        mvp.Item1.Disable();
        mvp.Item2.Disable();
        mvp.Item3.Disable();
    }
}