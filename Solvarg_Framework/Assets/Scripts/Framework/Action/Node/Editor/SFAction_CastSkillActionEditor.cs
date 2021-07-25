using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using XNode;
using SolvargAction;
using XMLib;
using UnityEditor;

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
                _target.comboType = EditorGUILayoutEx.DrawObject("触发连击方式", _target.comboType);
                if(_target.comboType == ComboEventType.InputEvents)
                {
                    EditorGUILayoutEx.DrawObject("触发事件",_target.comboEvents);
                }


                if (_target.skillConfigs == null || _target.skillConfigs.Count != _target.BaseState.animNames.Count)
                {
                    _target.skillConfigs = new List<SkillConfig>();
                    for (int i = 0; i < _target.BaseState.animNames.Count; ++i)
                    {
                        _target.skillConfigs.Add(null);
                    }
                    Debug.LogError("出错了");
                }
                for (int i = 0; i < _target.skillConfigs.Count; ++i)
                {
                    _target.skillConfigs[i] = EditorGUILayout.ObjectField("技能" + i.ToString(), _target.skillConfigs[i], typeof(SkillConfig), allowSceneObjects: true) as SkillConfig;
                }
            }



            serializedObject.ApplyModifiedProperties();
        }

        public override int GetWidth()
        {
            return 250;
        }
    }
}