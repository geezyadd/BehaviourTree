using Assets.Features.BehaviourTree.Scripts;

namespace Assets.Features.OgreModule.Script.BehaviourTreeTasks
{
    public class MeleeAttackTask : Node
    {
        private MeleeAttackComponent _meleeAttackComponent;
        private AttackSensorComponent _attackSensorComponent;

        public MeleeAttackTask(MeleeAttackComponent meleeAttackComponent, AttackSensorComponent attackSensorComponent)
        {
            _meleeAttackComponent = meleeAttackComponent;
            _attackSensorComponent = attackSensorComponent;
        }

        public override NodeState Evaluate()
        {
            if (_attackSensorComponent.IsCanMeleeAttack)
            {
                _meleeAttackComponent.MeleeAttack();
                return NodeState.Running;
            }
            else
            {
                return NodeState.Failure;
            }
        }
    }
}
