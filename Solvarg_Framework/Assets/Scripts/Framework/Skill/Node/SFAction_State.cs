using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SolvargSkill
{
    public class SFAction_State : SFAction_BaseActionNode
    {
        [AllowNesting]
        [Label("状态名")]
        public string stateName;
        [AllowNesting]
        [Label("动画trigger")]
        public string triggerName;



    }
}