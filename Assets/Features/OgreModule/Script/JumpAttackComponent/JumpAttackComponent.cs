using System;
using System.Collections;
using UnityEngine;

public class JumpAttackComponent : MonoBehaviour
{
    private const float JUMP_ATTACK_THRESHOLD = 2f;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private AnimationCurve _jumpCurve1;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _player;
    [SerializeField] private NavMeshComponent _navMeshComponent;
    [SerializeField] private float _jumpDuration = 1f;
    [SerializeField] private float _flexTime = 3f;
    [SerializeField] private float _delayBeforeJump = 0.5f;
    [SerializeField] private float _delayAfterJump = 1.5f;
    [SerializeField] private ParticleSystem _jumpEndParticleSystem;
    private float _jumpDistance;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private float _jumpTime;
    private bool _isJumping;
    public bool IsJumping => _isJumping;
    public event Action OnJumpEnd;

    public void JumpAttack()
    {
        if (_isJumping)
            return;
        _navMeshComponent.EnableNavMeshAgent(false);
        _isJumping = true;
        transform.forward = (_player.transform.position - transform.position).normalized;
        _startPosition = transform.position;
        _jumpTime = 0f;
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        _animator.SetTrigger("Flexing");
        yield return new WaitForSeconds(_flexTime);
        _animator.SetTrigger("JumpAttack");
        yield return new WaitForSeconds(_delayBeforeJump);

        _jumpDistance = Vector3.Distance(_player.transform.position, transform.position) - JUMP_ATTACK_THRESHOLD;
        Vector3 directionToPlayer = (_player.transform.position - transform.position).normalized;
        _targetPosition = transform.position + directionToPlayer * _jumpDistance;
        transform.forward = (_player.transform.position - transform.position).normalized;

        while (_jumpTime < _jumpDuration)
        {
            _jumpTime += Time.deltaTime;
            float normalizedTime = _jumpTime / _jumpDuration;

            if (normalizedTime >= 1f)
            {
                normalizedTime = 1f;
            }
            Vector3 horizontalPosition = Vector3.Lerp(_startPosition, _targetPosition, normalizedTime);

            float yOffset = _jumpCurve.Evaluate(normalizedTime);
            Vector3 currentPosition = new Vector3(horizontalPosition.x, _startPosition.y + yOffset * (_jumpDistance/3), horizontalPosition.z);
            //Vector3 currentPosition = new Vector3(horizontalPosition.x, _startPosition.y + yOffset * _jumpDistance, horizontalPosition.z);

            transform.position = currentPosition;
            if (transform.position.y <= 0)
            {
                transform.position = _targetPosition;
            }
            yield return new WaitForFixedUpdate();
        }
        _jumpEndParticleSystem.Play();
        yield return new WaitForSeconds(_delayAfterJump);
        _navMeshComponent.EnableNavMeshAgent(true);
        yield return null;
        _navMeshComponent.EnableNavMeshAgent(false);
        _animator.ResetTrigger("Flexing");
        _animator.ResetTrigger("JumpAttack");
        OnJumpEnd?.Invoke();
        _isJumping = false;
    }
}
