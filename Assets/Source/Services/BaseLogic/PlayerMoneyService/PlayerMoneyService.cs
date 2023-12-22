using System;
using UnityEngine;
using VContainer;

public class PlayerMoneyService
{
    private const string MoneyWalletSaveKey = "PlayerMoneyWallet";
    private const string GemsWalletSaveKey = "GemsWallet";
    
    private readonly DataStorageService _dataStorageService;
    
    private Wallet _moneyWallet;
    private Wallet _gemsWallet;

    public event Action<int> MoneyReceived;
    public event Action<int> MoneySpent; 
    
    [Inject]
    internal PlayerMoneyService(DataStorageService dataStorageService) => _dataStorageService = dataStorageService;

    public int MoneyCount => (int)_moneyWallet.MoneyCount;
    public int GemsCount => (int)_gemsWallet.MoneyCount;
    
    public void Init()
    {
        _moneyWallet = new Wallet(100);
        _gemsWallet = new Wallet(0);
        
        if(_dataStorageService.TryGetData(MoneyWalletSaveKey, out uint money))
            _moneyWallet.Init(money);

        if (_dataStorageService.TryGetData(GemsWalletSaveKey, out uint gems))
            _gemsWallet.Init(gems);

        _moneyWallet.Init(1000);
    }

    public void ReceiveMoney(int count)
    {
        Receive(count, _moneyWallet);

        _dataStorageService.SaveData<uint>(MoneyWalletSaveKey, _moneyWallet.MoneyCount);
    }

    public bool TrySpendMoney(uint required)
    {
        var isSuccess = TrySpend(required, _moneyWallet);
        
        if(isSuccess)
            _dataStorageService.SaveData<uint>(MoneyWalletSaveKey, _moneyWallet.MoneyCount);

        return isSuccess;
    }

    public void ReceiveGems(int count)
    {
        Receive(count, _gemsWallet);
        _dataStorageService.SaveData<uint>(GemsWalletSaveKey, _gemsWallet.MoneyCount);
    }

    public bool TrySpendGems(uint required)
    {
        var isSuccess = TrySpend(required, _gemsWallet);
        
        if(isSuccess)
            _dataStorageService.SaveData<uint>(GemsWalletSaveKey, _gemsWallet.MoneyCount);

        return isSuccess;
    }

    private void Receive(int count, Wallet wallet)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        var uintCount = (uint)count;

        wallet.ReceiveMoney(uintCount);

        MoneyReceived?.Invoke((int)wallet.MoneyCount);
    }

    private bool TrySpend(uint required, Wallet wallet)
    {
        bool isSuccess = wallet.TrySpendMoney(required);
        
        if(isSuccess)
            MoneySpent?.Invoke((int)wallet.MoneyCount);

        return isSuccess;
    }
}
