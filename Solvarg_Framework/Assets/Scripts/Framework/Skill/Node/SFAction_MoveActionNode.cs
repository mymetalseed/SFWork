using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolvargSkill
{
    [CreateNodeMenu("行为/移动Action")]
    public class SFAction_MoveActionNode : SFAction_BaseNode
    {
        [AllowNesting]
        [Label("移动速度")]
        public float moveSpeed;
        public override SF_NodeType GetNodeType => SF_NodeType.Behaviour;
    }
}