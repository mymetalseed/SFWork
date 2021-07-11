using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMLib;

namespace SolvargSkill
{
    public enum SFAction_ConditionType
    {
        None,
        KeyCode
    }

    [Serializable]
    public class ActionConditionBase
    {
        public virtual SFAction_ConditionType conditionType {
            get;
        }
        public virtual bool Execute(SF_ActionNode action) { return false; }
        public virtual Type _Type=>typeof(ActionConditionBase);
    }
    public class SF_Condition
    {
      

    }

    [Serializable]
    public class KeyCodeChecker : ActionConditionBase
    {
        [AllowNesting]
        [Label("是否")]
        public bool isNot;
        public bool fullMatch;

        public override SFAction_ConditionType conditionType => SFAction_ConditionType.KeyCode;

        public override bool Execute(SF_ActionNode action)
        {
            throw new NotImplementedException();
        }
        public override Type _Type => typeof(KeyCodeChecker);
    }

}