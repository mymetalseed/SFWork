using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SolvargAction
{
    [Serializable]
    public class PlayerReadyChecker : ActionConditionConfigBase
    {
        [AllowNesting]
        [Label("是否")]
        public bool isNot;

        public override SFAction_ConditionType conditionType => SFAction_ConditionType.PlayerReady;

        public override Type _Type => typeof(PlayerReadyChecker);

        public override bool Execute(SFAction_BaseActionNode action)
        {
            bool playerIsReady = SingletonManager.Instance._PlayerController.IsActive;
            return playerIsReady;
        }
    }
}