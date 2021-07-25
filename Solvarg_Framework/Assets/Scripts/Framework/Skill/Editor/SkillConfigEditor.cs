using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XMLib;

[CustomEditor(typeof(SkillConfig))]
public class SkillConfigEditor : Editor
{


    public override void OnInspectorGUI()
    {
        //SkillConfig config = target as SkillConfig;
        base.OnInspectorGUI();
        //EditorGUILayoutEx.DrawObject("技能列表",config);
    }
}
