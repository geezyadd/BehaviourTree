using Assets.Features.OgreModule.Script.EnemyMovement;
using UnityEngine;

public class TimerReseterSystem : MonoBehaviour
{
    [SerializeField] private SimpleMovementComponent _enemyMovementComponent;
    [SerializeField] private JumpAttackComponent _jumpAttackComponent;
    [SerializeField] private MeleeAttackComponent _meleeAttackComponent;

    private void OnEnable()
    {
        _jumpAttackComponent.OnJumpEnd += ResetTimer;
        _meleeAttackComponent.OnAttackStarted += ResetTimer;
    }

    private void OnDisable()
    {
        _jumpAttackComponent.OnJumpEnd -= ResetTimer;
        _meleeAttackComponent.OnAttackStarted -= ResetTimer;
    }

    private void ResetTimer()
    {
        _enemyMovementComponent.ResetTimer();
    }
} 
