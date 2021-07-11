using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using XNode;
using SolvargAction;
using XMLib;

namespace SolvargActionEditor
{
    [CustomNodeEditor(typeof(SFAction_MoveActionNode))]
    public class SFAction_MoveActionEditor : NodeEditor
    {
        SFAction_MoveActionNode _target;

        public override void OnHeaderGUI()
        {
            GUILayout.Label("角色移动Action", NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }

        public override void OnBodyGUI()
        {
            //base.OnBodyGUI();
            _target = target as SFAction_MoveActionNode;
            serializedObject.Update();
            NodeEditorGUILayout.PortField(target.GetInputPort("input"));
            _target.moveSpeed = EditorGUILayoutEx.DrawObject("移动速度", _target.moveSpeed);
            serializedObject.ApplyModifiedProperties();
        }

    }
}