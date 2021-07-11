using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SolvargSkill
{
    public enum SFAction_ConditionType
    {
        None,
        KeyCode,
        Ground
    }

    [Serializable]
    public class ActionConditionConfigBase
    {
        public virtual SFAction_ConditionType conditionType
        {
            get;
        }
        public virtual bool Execute(SF_ActionNode action) { return false; }
        public virtual Type _Type => typeof(ActionConditionConfigBase);
    }
}
