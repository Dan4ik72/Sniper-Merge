public class MergeButtonViewModel : IButtonViewModel
{
    private LevelWalletService _levelWalletService;
    private BulletSpawnService _bulletSpawnService;

    //temporary code (replace with config)
    private uint _mergeItemPrice;
    
    public MergeButtonViewModel(LevelWalletService levelWalletService, BulletSpawnService bulletSpawnService, uint mergeItemPrice)
    {
        _levelWalletService = levelWalletService;
        _bulletSpawnService = bulletSpawnService;
        _mergeItemPrice = mergeItemPrice;
    }
    
    public void OnButtonClick()
    {
        //if we can't spend money we should make the button inactive
        if(_levelWalletService.TrySpendMoney(_mergeItemPrice) == false)
            return;
        
        _bulletSpawnService.SpawnBullet(MergeItemType.Level1Item);
    }
}