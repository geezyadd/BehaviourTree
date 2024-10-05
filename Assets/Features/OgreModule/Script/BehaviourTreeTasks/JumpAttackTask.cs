
using Assets.Features.BehaviourTree.Scripts;
using Assets.Features.OgreModule.Script.EnemyMovement;

public class JumpAttackTask : Node
{
    private JumpAttackComponent _jumpAttackComponent;
    private SimpleMovementComponent _enemyMovementComponent;

    public JumpAttackTask(JumpAttackComponent jumpAttackComponent, SimpleMovementComponent enemyMovementComponent)
    {
        _jumpAttackComponent = jumpAttackComponent;
        _enemyMovementComponent = enemyMovementComponent;
    }

    public override NodeState Evaluate()
    {
        if (_enemyMovementComponent.TimerValue > 5)
        {
            _enemyMovementComponent.StopMove();
            _jumpAttackComponent.JumpAttack();
        }

        if (_jumpAttackComponent.IsJumping)
        {
            return NodeState.Running;
        }
        else
        {
            return NodeState.Failure;
        }
    }
}
