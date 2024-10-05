using System;
using UnityEngine;

public class PlayerInRangeToStartBattleSensor : MonoBehaviour
{
    public event Action OnBattleStarted;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnBattleStarted?.Invoke();
        }
    }
}
