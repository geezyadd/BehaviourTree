using Assets.Features.BehaviourTree.Scripts;
using UnityEngine;

public abstract class BehaviourTree : MonoBehaviour {
    private Node _rootNode = null;

    protected void Start() => _rootNode = SetubTree();

    private void Update() {
        if (_rootNode != null)
            _rootNode.Evaluate();
    }

    protected abstract Node SetubTree();
}
