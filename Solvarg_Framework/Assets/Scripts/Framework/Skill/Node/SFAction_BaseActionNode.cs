using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SolvargSkill
{
    public abstract class SFAction_BaseActionNode : Node
    {
        [Input(backingValue = ShowBackingValue.Never)]
        public SFAction_BaseActionNode input;
        [Output(backingValue = ShowBackingValue.Never)]
        public SFAction_BaseActionNode output;

        [AllowNesting]
        [Label("触发器类型")]
        public TriggerType trigType;
        [AllowNesting]
        [Label("触发延时(自动)")]
        public float duration;

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}