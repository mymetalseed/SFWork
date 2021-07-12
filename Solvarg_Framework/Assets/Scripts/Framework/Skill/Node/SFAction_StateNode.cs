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

        [Input(backingValue = ShowBackingValue.Always, typeConstraint = TypeConstraint.Strict)]
        public SFAction_StateNode input;

        [Output(backingValue = ShowBackingValue.Always, typeConstraint = TypeConstraint.Strict)]
        public SFAction_BaseActionNode output;

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
        public bool backToIdleState = true;
        /// <summary>
        /// 基本上下一个状态都是Idle
        /// </summary>
        public string nextStateName = "";
        public int nextAnimIndex = -1;

        public override string ToString() => stateName;

        public string defaultAnimName => GetAnimName(defaultAnimIndex);

        public override SF_NodeType GetNodeType => SF_NodeType.State;

        public string GetAnimName(int index)
        {
            return animNames?.Count > index ? animNames[index] : string.Empty;
        }

        /// <summary>
        /// 获取所有的action
        /// </summary>
        private List<SFAction_BaseActionNode> actions;
        private List<SFAction_BaseActionNode> Actions
        {
            get
            {
                if (actions == null)
                {
                    actions = new List<SFAction_BaseActionNode>();
                    NodePort port = null;
                    port = GetOutputPort("output");
                    for (int i = 0; i < port.ConnectionCount; ++i)
                    {
                        NodePort connection = port.GetConnection(i);
                        actions.Add((connection.node as SFAction_BaseActionNode));
                    }
                    return actions;
                }
                else return actions;
            }
        }


        #region 运行时
        private bool isRunning = false;
        /// <summary>
        /// 初次进入状态初始化
        /// </summary>
        public void StartState()
        {
            isRunning = true;
        }

        /// <summary>
        /// 等同于Update
        /// </summary>
        public override void Execute()
        {
            if (!isRunning) return;
            //如果没有动画,是一个独立状态
            //动画是供Action用的,保证就算不同动画状态机也可以用一套逻辑,只需要改名字就可以了

            //如果状态过程中可以跳转,则交给Action跳转,并且直接结束当前状态
            foreach(SFAction_BaseActionNode actionNode in Actions)
            {
                if (actionNode.DoAction())
                {
                    ExitState();
                    return;
                }
            }

            //如果不能循环,且没有跳转,则一次Execute之后就进入下一个状态
            if (!enableLoop)
            {
                if (backToIdleState)
                {
                    //回到Idle状态
                    Graph.ForceChangeState(this);
                    return;
                }
                //否则强行回到某一个状态
                Graph.ForceChangeState(this);
            }
        }

        /// <summary>
        /// 离开状态
        /// </summary>
        public void ExitState()
        {
            isRunning = false;
        }

        #endregion
    }
}