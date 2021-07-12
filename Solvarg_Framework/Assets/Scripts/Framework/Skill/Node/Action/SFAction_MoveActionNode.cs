using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolvargAction
{
    [CreateNodeMenu("行为/移动Action")]
    public class SFAction_MoveActionNode : SFAction_BaseActionNode
    {
        [AllowNesting]
        [Label("移动速度")]
        public float moveSpeed;
        public override SF_NodeType GetNodeType => SF_NodeType.Behaviour;

        public override bool DoAction()
        {
            string animName=null;
            if (BaseState.animNames != null && BaseState.animNames.Count>0)
            {
                animName = BaseState.animNames[0];
            }
            //控制Player移动
            SingletonManager.Instance._PlayerController.CheckMove(animName);

            return false;
        }
    }
}