using NaughtyAttributes;
using SolvargAction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillEffectInfo
{
    [AllowNesting]
    [Label("特效名称")]
    public string effectName;
    [AllowNesting]
    [Label("特效Id")]
    public string effectId;
    [AllowNesting]
    [Label("特效资源路径")]
    public string effectPath;
}

[CreateAssetMenu(fileName ="SkillEffectConfig",menuName ="Solvarg/SkillEffectConfig")]
public class SkillEffectConfig : ScriptableObject
{
    [Foldout("特效列表")]
    [Label("特效列表")]
    [ReorderableList]
    public List<SkillEffectInfo> infoList;

    [HideInInspector]
    public Dictionary<string, SkillEffectInfo> infoDict;

    /// <summary>
    /// 运行时初始化
    /// </summary>
    public void DoInit()
    {
        infoDict = new Dictionary<string, SkillEffectInfo>();
        foreach(SkillEffectInfo sei in infoList)
        {
            if (infoDict.ContainsKey(sei.effectId))
            {
                Debuger.LogError("出现重复特效ID");
            }
            else
            {
                infoDict.Add(sei.effectId, sei);
            }
        }
    }

}
