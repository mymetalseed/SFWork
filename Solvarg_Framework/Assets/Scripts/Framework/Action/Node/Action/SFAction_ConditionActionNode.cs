using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XNode;

namespace SolvargAction
{
    [CreateNodeMenu("触发条件")]
    public class SFAction_ConditionActionNode : SFAction_BaseActionNode
    {
        [AllowNesting]
        [Label("跳转状态名")]
        public string stateName;
        [AllowNesting]
        [Label("优先级")]
        public int priority;

        [Output(backingValue = ShowBackingValue.Always, typeConstraint = TypeConstraint.Strict)]
        public SFAction_StateNode nextState;

        [SerializeReference]
        public List<SFAction_Condition> checker;

        public override SF_NodeType GetNodeType => SF_NodeType.Condition;

        public override bool DoAction()
        {
            //检测每个条件
            bool pass = true;
            if (checker != null)
            {
                for (int i = 0; i < checker.Count; ++i)
                {
                    if (checker[i].cType != SFAction_ConditionType.None)
                    {
                        if (!checker[i].condition.Execute(this))
                        {
                            pass = false;
                        }
                    }
                }
            }
            if (pass)
            {
                NodePort output = GetOutputPort("nextState");
                if (output != null)
                {
                    SFAction_StateNode nextState = output.GetConnection(0).node as SFAction_StateNode;
                    if (!Graph.ForceChangeState(BaseState, nextState))
                    {
                        //尝试切换状态失败,比如下一个状态的冷却时间没达到
                        pass = false;
                    }
                }
            }
            //如果通过检测的话,自动跳转到下一个状态,然后返回true
            return pass;
        }

        public override void EnterAction()
        {
        }

        public override void ExitAction()
        {
        }
    }

    [Serializable]
    public class SFAction_Condition
    {
        [AllowNesting]
        [Label("条件类型")]
        [OnValueChanged("ResetCondition")]
        public SFAction_ConditionType cType;

        public SFAction_ConditionType CType
        {
            set
            {
                if (value != cType)
                {
                    cType = value;
                    ResetCondition();
                }
            }
        }
        [SerializeReference]
        public ActionConditionConfigBase condition;

        public Type GetConditionType()
        {
            return condition._Type;
        }

        public void ResetCondition()
        {
            if (cType == SFAction_ConditionType.KeyCode)
            {
                condition = new KeyCodeChecker();
            }else if(cType == SFAction_ConditionType.Ground)
            {
                condition = new GroundChecker();
            }
            else if (cType == SFAction_ConditionType.PlayerReady)
            {
                condition = new PlayerReadyChecker();
            }
        }
    }
}