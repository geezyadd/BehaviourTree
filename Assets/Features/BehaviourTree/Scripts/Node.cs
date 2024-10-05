using System;
using System.Collections.Generic;

namespace Assets.Features.BehaviourTree.Scripts {
    public class Node
    {
        private NodeState _currentState;

        public NodeState NodeState
        {
            get =>
                _currentState;
            set
            {
                _currentState = value;
                OnCurrentStateChanged?.Invoke(value);
            }
        }

        public Node Parent;
        public List<Node> Children = new();

        public event Action<NodeState> OnCurrentStateChanged;

        private Dictionary<string, object> _dataContext = new();

        public Node() =>
            Parent = null;

        public Node(List<Node> children)
        {
            foreach (Node child in children)
                Attach(child);
        }

        public void Attach(Node node)
        {
            node.Parent = this;
            Children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.Failure;

        public void SetData(string key, object value)
        {
            _dataContext.Add(key, value);
        }

        public object GetData(string key)
        {
            object value = null;
            if (_dataContext.TryGetValue(key, out value))
                return value;

            Node node = Parent;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                    return value;
                node = node.Parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = Parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.Parent;
            }
            return false;
        }
    }
}