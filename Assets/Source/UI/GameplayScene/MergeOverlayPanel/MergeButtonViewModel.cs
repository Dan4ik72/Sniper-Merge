using UnityEngine;

public class MergeButtonViewModel : IButtonViewModel
{
    private LevelWalletService _levelWalletService;
    private BulletSpawnService _bulletSpawnService;

    private uint _mergeItemPrice;

    private float _increasingPriceStep = 1.5f;
        
    public MergeButtonViewModel(LevelWalletService levelWalletService, BulletSpawnService bulletSpawnService, uint mergeItemPrice)
    {
        _levelWalletService = levelWalletService;
        _bulletSpawnService = bulletSpawnService;
        _mergeItemPrice = mergeItemPrice;
    }

    public int CurrentPrice => (int)_mergeItemPrice;
    
    public void OnButtonClick()
    {
        //if we can't spend money we should make the button inactive
        if(_levelWalletService.TrySpendMoney(_mergeItemPrice) == false)
            return;

        _mergeItemPrice = (uint)(_mergeItemPrice * _increasingPriceStep);

        _bulletSpawnService.SpawnBullet(MergeItemType.ItemLevel1);
    }
}