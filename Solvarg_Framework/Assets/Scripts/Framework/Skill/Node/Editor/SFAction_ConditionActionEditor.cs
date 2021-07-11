using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using XNode;
using XMLib;
using UnityEditor;

namespace SolvargAction
{
    [CustomNodeEditor(typeof(SFAction_ConditionActionNode))]
    public class SFAction_ConditionActionEditor : NodeEditor
    {
        SFAction_ConditionActionNode _target;
        private bool fade=true;

        public override void OnHeaderGUI()
        {
            GUILayout.Label("条件Action", NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }

        public override void OnBodyGUI()
        {
            //base.OnBodyGUI();
            
            _target = target as SFAction_ConditionActionNode;
            serializedObject.Update();
            
            NodeEditorGUILayout.PortField(target.GetInputPort("input"));
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("提示: 该行为为一个行为组", GUI.skin.GetStyle("PR Ping"));
            EditorGUILayout.Space();
            NodeEditorGUILayout.PortField(new GUIContent("下一个状态"), target.GetOutputPort("output"));
            _target.priority = EditorGUILayoutEx.DrawObject("优先级", _target.priority);
            //_target.stateName = EditorGUILayoutEx.DRAW("跳转状态名", _target.stateName);

            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("Tab onlyOne"));
            fade = EditorGUILayout.Foldout(fade, "跳转条件列表");

            if (fade)
            {
                bool first = true;
                if (_target.checker != null)
                {
                    foreach (SFAction_Condition cd in _target.checker)
                    {
                        if (first)
                        {
                            first = false;
                        }
                        else
                        {
                            EditorGUILayout.Space(10);
                        }
                        EditorGUILayout.BeginVertical(GUI.skin.GetStyle("TE DefaultTime"));

                        cd.CType = EditorGUILayoutEx.DrawObject("条件类型", cd.cType);
                        if (cd.cType != SFAction_ConditionType.None && cd.condition != null)
                        {
                            EditorGUILayoutEx.DrawObject(GUIContent.none, cd.condition, cd.GetConditionType());

                        }
                        if (GUILayout.Button(GUIContent.none, GUI.skin.GetStyle("OL Minus"), GUILayout.Height(20)))
                        {

                            _target.checker.Remove(cd);

                            break;

                        }
                        EditorGUILayout.EndVertical();
                    }
                }
                if (GUILayout.Button(GUIContent.none, GUI.skin.GetStyle("OL Plus"), GUILayout.Height(20)))
                {
                    if (_target.checker != null)
                    {
                        _target.checker.Add(new SFAction_Condition());
                    }
                    else
                    {
                        _target.checker = new List<SFAction_Condition>();
                    }
                }
            }
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }

        void SaveAsset()
        {
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}