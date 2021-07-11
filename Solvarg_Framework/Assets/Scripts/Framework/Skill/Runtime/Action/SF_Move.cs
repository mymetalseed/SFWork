using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolvargAction
{
    [Serializable]
    public class MoveConfig
    {
        public float moveSpeed;
    }

    public class SF_Move : IActionHandler
    {
        public void Enter(SF_ActionNode node)
        {
        }

        public void Exit(SF_ActionNode node)
        {
        }

        public void Update(SF_ActionNode node, float deltaTime)
        {
            MoveConfig config = node.config as MoveConfig;
            //do移动

        }
    }
}