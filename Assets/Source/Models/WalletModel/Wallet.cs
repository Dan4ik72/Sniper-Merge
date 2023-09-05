public class Wallet
{
    private uint _moneyCount = 0;
    
    public Wallet(uint startMoneyCount = 0)
    {
        _moneyCount = startMoneyCount;
    }

    public uint MoneyCount => _moneyCount;

    public void ReceiveMoney(uint money)
    {
        _moneyCount += money;
    }

    public bool TrySpendMoney(uint requiredCount)
    {
        if (requiredCount > _moneyCount)
            return false;

        _moneyCount -= requiredCount;
        
        return true;
    }
}
