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
        [Input(backingValue = ShowBackingValue.Always,typeConstraint =TypeConstraint.InheritedAny)]
        public SFAction_BaseNode input;
        [Output(backingValue = ShowBackingValue.Always, typeConstraint = TypeConstraint.InheritedAny)]
        public SFAction_BaseNode output;

        public abstract SF_NodeType GetNodeType
        {
            get;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}