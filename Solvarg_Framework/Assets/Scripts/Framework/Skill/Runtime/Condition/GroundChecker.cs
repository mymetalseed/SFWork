using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolvargAction
{
    [Serializable]
    public class GroundChecker : ActionConditionConfigBase
    {
        [AllowNesting]
        [Label("是否取反")]
        public bool isNot;
        [AllowNesting]
        [Label("地面Layer")]
        public LayerMask groundMask;

        public override SFAction_ConditionType conditionType => SFAction_ConditionType.Ground;

        public override Type _Type => typeof(GroundChecker);

        public override bool Execute(SF_ActionNode action)
        {
            return base.Execute(action);
        }
    }
}