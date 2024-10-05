using Assets.Features.BehaviourTree.Scripts;
using Assets.Features.OgreModule.Script.EnemyMovement;

namespace Assets.Features.OgreModule.Script.BehaviourTreeTasks
{
    public class TaskGoToPlayer : Node
    {
        private SimpleMovementComponent _enemyMovementComponent;
        private AttackSensorComponent _attackSensorComponent;
        private MeleeAttackComponent _meleeAttackComponent;

        public TaskGoToPlayer(SimpleMovementComponent enemyMovementCompponent, AttackSensorComponent attackSensorComponent, MeleeAttackComponent meleeAttackComponent)
        {
            _enemyMovementComponent = enemyMovementCompponent;
            _attackSensorComponent = attackSensorComponent;
            _meleeAttackComponent = meleeAttackComponent;
        }

        public override NodeState Evaluate()
        {
            if (_enemyMovementComponent.TimerValue > 5)
            {
                _enemyMovementComponent.StopMove();
                return NodeState.Failure;
            }
            else if (!_attackSensorComponent.IsCanMeleeAttack && _meleeAttackComponent.IsAttackEnded)
            {
                _enemyMovementComponent.MoveToPlayer();
                return NodeState.Running;
            }
            else
            {
                _enemyMovementComponent.StopMove();
                return NodeState.Success;
            }
        }


    }
}