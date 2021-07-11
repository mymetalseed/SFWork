using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolvargAction
{
    public interface IActionHandler
    {
        void Enter(SF_ActionNode node);

        void Exit(SF_ActionNode node);

        void Update(SF_ActionNode node, Single deltaTime);
    }
}