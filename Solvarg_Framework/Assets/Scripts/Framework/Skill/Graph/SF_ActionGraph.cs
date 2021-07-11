using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
namespace SolvargAction
{
    [CreateAssetMenu(menuName = "Solvarg/Action/New Action Graph", order = 0)]
    public class SF_ActionGraph : NodeGraph
    {
        public string roleId;
        public SFAction_StateNode startState;
        public void SatrtAction()
        {

        }
    }
}