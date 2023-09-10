using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

internal class BuffButtonViewModel
{
    private BuffProcessingService _buffProcessingService;
    private LevelWalletService _levelWalletService;
    
    private Buff _buff;

    private bool _isAvailable = true;
    private bool _isUsing = false;

    public event Action<bool> ButtonStateChanged;
    public event Action<int> TimerTicked;
    public event Action TimerEnded;
    public event Action TimerStarted;
    
    internal BuffButtonViewModel(Buff buff, BuffProcessingService buffProcessingService, LevelWalletService levelWalletService)
    {
        _buff = buff;
        _buffProcessingService = buffProcessingService;
        _levelWalletService = levelWalletService;
    }

    public void Init()
    {
        UpdateButtonState();

        _levelWalletService.MoneySpent += UpdateButtonState;
        _buffProcessingService.BuffEnded += OnBuffEnded;
    }

    public void Disable()
    {
        _levelWalletService.MoneySpent -= UpdateButtonState;
        _buffProcessingService.BuffEnded -= OnBuffEnded;
    }
    
    public void OnButtonClicked()
    {
        if(_levelWalletService.TrySpendMoney((uint)_buff.UsagePrice) == false)
            return;
        
        _buffProcessingService.ApplyBuff(_buff);

        _isAvailable = false;
        _isUsing = true;
        StartTimer((int)_buff.Duration);
    }

    private void OnBuffEnded(Buff buff)
    {
        if(buff != _buff)
            return;

        _isUsing = false;
        UpdateButtonState();
    }

    private void UpdateButtonState(uint money = 0)
    {
        if (_isUsing)
        {
            ButtonStateChanged?.Invoke(false);
            return;
        }

        if (_buff.UsagePrice > _levelWalletService.GetCurrentMoneyCount())
            _isAvailable = false;
        else
            _isAvailable = true;

        ButtonStateChanged?.Invoke(_isAvailable);
    }

    private async UniTask StartTimer(int time)
    {
        TimerStarted?.Invoke();
        ButtonStateChanged?.Invoke(_isAvailable);
        
        for (int i = time; i > 0; i--)
        {
            TimerTicked?.Invoke(i);
            
            await UniTask.WaitForSeconds(1);
        }

        TimerEnded?.Invoke();
    }
}