using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
namespace SolvargSkill
{
    [CreateAssetMenu(menuName = "Solvarg/Skill/New Skill Graph", order = 0)]
    public class SF_SkillGraph : NodeGraph
    {
        public string skillId;
        public SFAction_StateNode startState;
        public void SatrtAction()
        {

        }
    }
}