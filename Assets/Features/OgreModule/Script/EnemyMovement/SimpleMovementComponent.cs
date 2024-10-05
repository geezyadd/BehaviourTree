using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Features.OgreModule.Script.EnemyMovement
{
    public class SimpleMovementComponent : MonoBehaviour, IEnemyMovementCompponent
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private NavMeshComponent _navMeshComponent;
        [SerializeField] private AnimationsController _animationController;
        private Coroutine _moveCoroutine;
        private bool _isMoving;
        private float _timer;
        public float TimerValue =>
            _timer;

        public void MoveToPlayer()
        {
            if (_isMoving)
                return;
            _navMeshComponent.EnableNavMeshAgent(true);
            _animationController.PlayAnimation("Run");
            _moveCoroutine = StartCoroutine(MoveCoroutine());
        }

        public void StopMove()
        {
            if (!_isMoving)
                return;
            _navMeshComponent.ResetPath();
            _isMoving = false;
            if (_moveCoroutine != null)
                StopCoroutine(_moveCoroutine);
        }

        public void ResetTimer()
        {
            _timer = 0;
        }

        private IEnumerator MoveCoroutine()
        {
            WaitForSeconds setDestinationDelay = new WaitForSeconds(0.2f);
            _isMoving = true;
            while (_isMoving)
            {
                //Debug.LogError(_timer);
                _timer += 0.2f;
                _navMeshComponent.SetDestination(_player.transform.position);
                yield return setDestinationDelay;
            }
        }
    }
}