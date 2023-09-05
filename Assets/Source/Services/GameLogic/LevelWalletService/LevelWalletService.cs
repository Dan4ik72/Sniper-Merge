using System;
using UnityEngine;
using VContainer;

public class LevelWalletService
{
    private Wallet _levelWallet;

    public event Action<uint> MoneySpent;
    public event Action<uint> MoneyReceived;

    [Inject]
    public LevelWalletService(Wallet levelWallet)
    {
        _levelWallet = levelWallet;
        _levelWallet.ReceiveMoney(20);
    }
    
    public uint GetCurrentMoneyCount() => _levelWallet.MoneyCount;
    
    public void ReceiveMoney(uint count)
    {
        _levelWallet.ReceiveMoney(count);

        MoneyReceived?.Invoke(count);
    }

    public bool TrySpendMoney(uint required)
    {
        bool isSuccess = _levelWallet.TrySpendMoney(required);
        
        if(isSuccess)
            MoneySpent?.Invoke(_levelWallet.MoneyCount);

        return isSuccess;
    }
}
