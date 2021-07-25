using SolvargAction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace SolvargActionEditor
{
    [CustomNodeGraphEditor(typeof(SF_ActionGraph))]
    public class ActionGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(Type type)
        {
            if (type.Namespace == "SolvargAction")
            {
                return base.GetNodeMenuName(type).Replace("SolvargAction/", "");
            }
            else return null;
        }
    }
}