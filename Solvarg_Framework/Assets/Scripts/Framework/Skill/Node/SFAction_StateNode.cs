using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace SolvargAction
{
    [CreateNodeMenu("状态/State")]
    public class SFAction_StateNode : SFAction_BaseNode
    {
        [AllowNesting]
        [Label("状态名")]
        public string stateName="State";
        [AllowNesting]
        [Label("默认动画序号")]
        public int defaultAnimIndex = 0;

        [AllowNesting]
        [Label("Trigger名称")]
        public List<string> animNames;

        [AllowNesting]
        [Label("过渡时间")]
        public Single fadeTime = 1 / (Single)20;
        public bool enableLoop = false;
        public string nextStateName = "";
        public int nextAnimIndex = -1;

        public override string ToString() => stateName;

        public string defaultAnimName => GetAnimName(defaultAnimIndex);

        public override SF_NodeType GetNodeType => SF_NodeType.State;

        public string GetAnimName(int index)
        {
            return animNames?.Count > index ? animNames[index] : string.Empty;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}