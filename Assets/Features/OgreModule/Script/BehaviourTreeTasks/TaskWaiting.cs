
using Assets.Features.BehaviourTree.Scripts;

public class TaskWaiting : Node
{
    private WaitingComponent _waitingComponent;

    public TaskWaiting(WaitingComponent waitingComponent) =>
        _waitingComponent = waitingComponent;

    public override NodeState Evaluate()
    {
        if (_waitingComponent.CheckIsWaitingInProgress())
            return NodeState.Running;
        else
            return NodeState.Failure;
    }
}
