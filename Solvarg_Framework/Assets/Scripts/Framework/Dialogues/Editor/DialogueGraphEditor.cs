using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using Dialogue;

namespace DialogueEditor
{
    [CustomNodeGraphEditor(typeof(DialogueGraph))]
    public class DialogueGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(System.Type type)
        {
            if (type.Namespace == "Dialogue") return base.GetNodeMenuName(type).Replace("Dialogue/", "");
            else return null;
        }
    }
}