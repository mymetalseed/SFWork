using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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

        [SerializeReference]
        public List<SFAction_Condition> checker;

        public override SF_NodeType GetNodeType => SF_NodeType.Condition;

        public override bool DoAction()
        {
            //检测每个条件
            bool res = false;
            if (checker != null)
            {
                for (int i = 0; i < checker.Count; ++i)
                {
                    if (checker[i].cType != SFAction_ConditionType.None)
                    {
                        res = checker[i].condition.Execute(this);
                        if (res) return true;
                    }
                }
            }
            return false;
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
        }
    }
}