using Assets.Features.BehaviourTree.Scripts;
using System.Collections.Generic;

public class Sequence : Node
{
    public Sequence() : base() { }
    public Sequence(List<Node> children) : base(children) { }
    public override NodeState Evaluate()
    {
        bool anyChildrenRunning = false;
        foreach(Node child in Children)
        {
            switch (child.Evaluate())
            {
                case NodeState.Failure:
                    NodeState = NodeState.Failure;
                    return NodeState;
                case NodeState.Success:
                    continue;
                case NodeState.Running:
                    NodeState = NodeState.Running;
                    return NodeState;
                default:
                    NodeState = NodeState.Success;
                    return NodeState;
            }
        }
        NodeState = anyChildrenRunning ? NodeState.Running : NodeState.Success;
        return NodeState;
    }
}
