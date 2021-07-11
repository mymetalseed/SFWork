using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolvargAction
{
    [Serializable]
    public class KeyCodeChecker : ActionConditionConfigBase
    {
        /// <summary>
        /// 这个后面会改成输入事件
        /// </summary>
        [AllowNesting]
        [Label("响应按键")]
        public KeyCode inputEvents;
        [AllowNesting]
        [Label("是否")]
        public bool isNot;
        [AllowNesting]
        [Label("完全匹配")]
        public bool fullMatch;

        public override SFAction_ConditionType conditionType => SFAction_ConditionType.KeyCode;

        public override bool Execute(SF_ActionNode action)
        {
            throw new NotImplementedException();
        }
        public override Type _Type => typeof(KeyCodeChecker);
    }
}