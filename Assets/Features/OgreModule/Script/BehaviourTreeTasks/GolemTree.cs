using Assets.Features.BehaviourTree.Scripts;
using Assets.Features.OgreModule.Script.BehaviourTreeTasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GolemTree : BehaviourTree
{
    private DiContainer _diContainer;
    [SerializeField] private GameObjectContext _gameObjectContext;

    private void Start()
    {
        _diContainer = _gameObjectContext.Container;
        base.Start();
    }

    protected override Node SetubTree()
    {
        Node root = new Selector(new List<Node>
        {
            _diContainer.Instantiate<TaskWaiting>(),
            new Sequence(new List<Node>
            {
                new Selector(new List<Node>
                {
                    _diContainer.Instantiate<TaskGoToPlayer>(),
                    _diContainer.Instantiate<JumpAttackTask>(),
                }),
                _diContainer.Instantiate<MeleeAttackTask>(),
            }),
        });
        return root;
    }
}
