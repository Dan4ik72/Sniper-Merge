public class BoostReloadButtonModel : IButtonViewModel
{
    private ShootingService _shootingService;

    private float _time = 0.5f;

    public BoostReloadButtonModel(ShootingService shootingService)
    {
        _shootingService = shootingService;
    }

    public void OnButtonClick()
    {
        _shootingService.BoostReload(_time);
    }
}
