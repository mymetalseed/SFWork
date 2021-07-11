using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolvargSkill
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
            throw new System.NotImplementedException();
        }

        public void Exit(SF_ActionNode node)
        {
            throw new System.NotImplementedException();
        }

        public void Update(SF_ActionNode node, float deltaTime)
        {
            MoveConfig config = node.config as MoveConfig;
            //do移动
        }
    }
}