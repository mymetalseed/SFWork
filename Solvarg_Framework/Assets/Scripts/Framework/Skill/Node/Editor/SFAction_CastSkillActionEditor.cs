using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using XNode;
using SolvargAction;
using XMLib;

namespace SolvargActionEditor
{
    [CustomNodeEditor(typeof(SFAction_CastSkillActionNode))]
    public class SFAction_CastSkillActionEditor : NodeEditor
    {
        SFAction_CastSkillActionNode _target;

        public override void OnHeaderGUI()
        {
            GUILayout.Label("释放技能Action", NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }
        public override void OnBodyGUI()
        {
            //base.OnBodyGUI();
            _target = target as SFAction_CastSkillActionNode;

            serializedObject.Update();
            NodeEditorGUILayout.PortField(target.GetInputPort("input"));
            _target.isCombo = EditorGUILayoutEx.DrawObject("是否连击", _target.isCombo);

            if (_target.isCombo)
            {
                _target.comboType = EditorGUILayoutEx.DrawObject("连击触发方式",_target.comboType);
                if(_target.comboType == ComboEventType.InputEvents)
                {
                    EditorGUILayoutEx.DrawObject("触发输入事件",_target.comboEvents);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}