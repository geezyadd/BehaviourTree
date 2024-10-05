using System;
using UnityEngine;

public class WaitingComponent : MonoBehaviour
{
    [SerializeField] private AnimationsController _animationsController;
    [SerializeField] private PlayerInRangeToStartBattleSensor _playerInRangeToStartBattleSensor;
    private bool _isPlayerInRangeToStartBattle;
    public event Action OnStopWaiting;
    private void OnEnable()
    {
        _playerInRangeToStartBattleSensor.OnBattleStarted += StopWaiting;
    }
    private void OnDisable()
    {
        _playerInRangeToStartBattleSensor.OnBattleStarted -= StopWaiting;
    }

    public void StartWaiting()
    {
        _isPlayerInRangeToStartBattle = false;
        _animationsController.ResetAllTriggers();
    }

    public bool CheckIsWaitingInProgress()
    {
        return !_isPlayerInRangeToStartBattle;
    }

    private void StopWaiting()
    {
        _isPlayerInRangeToStartBattle = true;
        OnStopWaiting?.Invoke();
    }
}
