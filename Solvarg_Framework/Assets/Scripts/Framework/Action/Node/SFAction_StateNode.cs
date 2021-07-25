using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace SolvargAction
{
    public enum SFAction_TriggerType{
        None,
        Auto,
        Trigger
    }



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

        [AllowNesting]
        [Label("冷却时间")]
        public Single coolDownTime = 1 / (Single)10;

        [AllowNesting]
        [Label("循环")]
        public bool enableLoop = false;
        [AllowNesting]
        [Label("返回Idle的方式")]
        public SFAction_TriggerType backToIdleState = SFAction_TriggerType.Auto;

        private bool backIdleTrigger = false;

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
        private List<SFAction_BaseActionNode> Actions
        {
            get
            {
                List<SFAction_BaseActionNode> actions = new List<SFAction_BaseActionNode>();
                NodePort port = null;
                port = GetOutputPort("output");
                for (int i = 0; i < port.ConnectionCount; ++i)
                {
                    NodePort connection = port.GetConnection(i);
                    actions.Add((connection.node as SFAction_BaseActionNode));
                }
                return actions;
            }
        }


        #region 运行时
        private bool isRunning = false;
        public bool IsRunning => (isRunning);

        public float startTime;

        private void Awake()
        {
            isRunning = false;
        }

        /// <summary>
        /// 初次进入状态初始化
        /// </summary>
        public void StartState()
        {
            if (backToIdleState == SFAction_TriggerType.Trigger)
            {
                backIdleTrigger = false;
            }

            //初始化Action
            foreach (SFAction_BaseActionNode actionNode in Actions)
            {
                actionNode.EnterAction();
            }
            startTime = Time.time;
            isRunning = true;
            Debuger.Log("当前Action系统进入状态: " + stateName);
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
                bool changeSuccess=false;
                if (backToIdleState==SFAction_TriggerType.Auto)
                {
                    //回到Idle状态
                    changeSuccess = Graph.ForceChangeState(this);
                    return;
                }else if(backToIdleState == SFAction_TriggerType.Trigger)
                {
                    if (backIdleTrigger)
                    {
                        //根据Trigger判断
                        changeSuccess = Graph.ForceChangeState(this);
                        //TODO: 这里是按照Trigger的方式转换的,如果失败的话该怎么处理.?
                    }
                }
                else
                {
                    //否则强行回到某一个状态
                    changeSuccess = Graph.ForceChangeState(this);
                }
            }
        }

        /// <summary>
        /// 离开状态
        /// </summary>
        public void ExitState()
        {
            foreach (SFAction_BaseActionNode actionNode in Actions)
            {
                actionNode.ExitAction();
            }

            isRunning = false;
        }

        /// <summary>
        /// 有连击的技能或普攻在这里设置为执行完毕
        /// </summary>
        public void SetComboTrigger()
        {
            backIdleTrigger = true;
        }

        #endregion
    }
}