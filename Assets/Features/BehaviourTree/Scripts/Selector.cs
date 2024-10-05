using Assets.Features.BehaviourTree.Scripts;
using System.Collections.Generic;

public class Selector : Node
{
    public Selector() : base() { }
    public Selector(List<Node> children) : base(children) { }
    public override NodeState Evaluate()
    {
        foreach (Node child in Children)
        {
            switch (child.Evaluate())
            {
                case NodeState.Failure:
                    continue;
                case NodeState.Success:
                    NodeState = NodeState.Success;
                    return NodeState;
                case NodeState.Running:
                    NodeState = NodeState.Running;
                    return NodeState;
                case NodeState.None:
                    break;
                default:
                    continue;
            }
        }
        NodeState = NodeState.Failure;
        return NodeState;
    }
}
