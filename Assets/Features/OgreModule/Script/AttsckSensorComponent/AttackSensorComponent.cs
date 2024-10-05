using System;
using System.Collections;
using UnityEngine;

public class AttackSensorComponent : MonoBehaviour
{
    public event Action CanMeleeAttack;
    public event Action NotEnoughRangeForMeeleAttack;
    public bool IsCanMeleeAttack;
    private Coroutine _triggerExitCoroutine;

    private void Awake()
    {
        NotEnoughRangeForMeeleAttack?.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerDamageable>(out PlayerDamageable damageable))
        {
            IsCanMeleeAttack = true;
            CanMeleeAttack?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerDamageable>(out PlayerDamageable damageable))
        {
            if(_triggerExitCoroutine != null)
            {
                StopCoroutine(_triggerExitCoroutine);
            }
            _triggerExitCoroutine = StartCoroutine(InvokeNotEnoughRangeForMeeleAttackWithDelay());
        }
    }

    private IEnumerator InvokeNotEnoughRangeForMeeleAttackWithDelay()
    {
        yield return new WaitForSeconds(1);
        IsCanMeleeAttack = false;
        NotEnoughRangeForMeeleAttack?.Invoke();
    }

   
}
