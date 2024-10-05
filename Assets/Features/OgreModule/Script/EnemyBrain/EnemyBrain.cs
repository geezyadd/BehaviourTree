
using Assets.Features.OgreModule.Script.EnemyMovement;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private AttackSensorComponent _attackSensorComponent;
    [SerializeField] private SimpleMovementComponent _enemyMovementComponent;
    [SerializeField] private NavMeshComponent _enemyNavMeshComponent;
    [SerializeField] private MeleeAttackComponent _meleeAttackComponent;
    [SerializeField] private JumpAttackComponent _jumpAttackComponent;
    [SerializeField] private RocksAttackComponent _rocksAttackComponent;

}
