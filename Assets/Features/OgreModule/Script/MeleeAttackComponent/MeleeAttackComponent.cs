using System;
using System.Collections;
using UnityEngine;

public class MeleeAttackComponent : MonoBehaviour
{
    [SerializeField] private AnimationsController _animationsController;
    [SerializeField] private GameObject _player;
    [SerializeField] private float rotationTime = 2.0f;
    [SerializeField] private NavMeshComponent _navMeshComponent;
    private bool _isAttackEnded = true;
    public bool IsAttackEnded =>
        _isAttackEnded;

    public event Action OnAttackStarted;

    public void MeleeAttack()
    {
        if(!_isAttackEnded)
            return;
        OnAttackStarted?.Invoke();
        _isAttackEnded = false;
        _navMeshComponent.EnableNavMeshAgent(false);
        StartCoroutine(RotateToPlayerCoroutine());

        _animationsController.PlayAnimation("Attack");

    }

    private IEnumerator RotateToPlayerCoroutine()
    {
        Vector3 playerDirection = (_player.transform.position - transform.position).normalized;
        Vector3 flatDirection = new Vector3(playerDirection.x, 0, playerDirection.z);
        Quaternion targetRotation = Quaternion.LookRotation(flatDirection);
        float angleOffset = -30f; 
        Quaternion offsetRotation = Quaternion.AngleAxis(angleOffset, Vector3.up);

        Quaternion finalRotation = targetRotation * offsetRotation;
        Quaternion initialRotation = transform.rotation;

        float elapsedTime = 0f;

        while (elapsedTime < rotationTime)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, elapsedTime / rotationTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }

    public void SetIsAttackEnded()
    {
        _isAttackEnded = true;
    }
}
