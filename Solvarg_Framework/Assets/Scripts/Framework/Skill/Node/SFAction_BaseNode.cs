using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SolvargSkill
{
    public enum SF_NodeType
    {
        State,
        Condition
    }

    public abstract class SFAction_BaseNode : Node
    {
        [Input(backingValue = ShowBackingValue.Always)]
        public SFAction_BaseNode input;
        [Output(backingValue = ShowBackingValue.Always)]
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