using SolvargSkill;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace SolvargSkillEditor
{
    [CustomNodeGraphEditor(typeof(SF_SkillGraph))]
    public class SkillGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(Type type)
        {
            if (type.Namespace == "SolvargSkill")
            {
                return base.GetNodeMenuName(type).Replace("SolvargSkill/", "");
            }
            else return null;
        }
    }
}