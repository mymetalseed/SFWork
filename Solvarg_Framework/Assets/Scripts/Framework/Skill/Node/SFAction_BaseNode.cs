using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SolvargAction
{
    public enum SF_NodeType
    {
        State,
        Condition,
        Behaviour
    }

    public abstract class SFAction_BaseNode : Node
    {
        private SF_ActionGraph _graph;

        protected SF_ActionGraph Graph
        {
            get
            {
                if (_graph == null)
                {
                    _graph = graph as SF_ActionGraph;
                }
                return _graph;
            }
        }

        public abstract SF_NodeType GetNodeType
        {
            get;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
        public abstract void Execute();
    }
}