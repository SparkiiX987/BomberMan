using System.Collections.Generic;


namespace BehaviourTree
{
    // etat du noeud
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }


    public class Node
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        //constructeur
        public Node() 
        {
            parent = null;
        }
        public Node(List<Node> children)
        {
            foreach (Node child in children)
                Attach(child);
        }
        private void Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;

        // set data
        public void SetData(string key, object value)
        {
            dataContext[key] = value;
        }

        //get data by his key in all the tree
        public object GetData(string key)
        {
            object value = null;
            if(dataContext.TryGetValue(key, out value))
                return value;

            Node node = parent;
            while(node != null)
            {
                value = node.GetData(key);
                if (value != null) 
                    return value;
                node = node.parent;
            }

            return null;
        }


        public bool ClearData(string key)
        {
            if (dataContext.ContainsKey(key))
            {
                dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }

            return false;
        }

    }
}


