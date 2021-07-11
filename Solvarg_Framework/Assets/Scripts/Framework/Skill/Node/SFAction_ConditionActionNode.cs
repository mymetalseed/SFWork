using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SolvargSkill
{
    [CreateNodeMenu("触发条件")]
    public class SFAction_ConditionActionNode : SFAction_BaseNode
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