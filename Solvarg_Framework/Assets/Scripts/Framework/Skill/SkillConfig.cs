using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillShowPattern 
{
    RoleOrigin,//以角色为中心
    PointerOrigin,//指向型
    RandomOrigin,//随机自行选定目标...
}
[Serializable]
public class SkillEffectDisplayInfo
{
    [AllowNesting]
    [Label("特效Id")]
    public string effectId;
    [AllowNesting]
    [Label("显示位置")]
    public Vector3 pos;
    [AllowNesting]
    [Label("显示旋转")]
    public Vector3 rot;
    [AllowNesting]
    [Label("显示缩放")]
    public Vector3 scale;
    [AllowNesting]
    [Label("是否生成在角色身上")]
    public bool isLocal;
    [AllowNesting]
    [Label("挂载节点名称")]
    public string targetName;
    [AllowNesting]
    [Label("显示延时")]
    public float duration;
    [AllowNesting]
    [Label("存在时间")]
    public float existTimer;
}
[CreateAssetMenu(fileName = "SkillConfig", menuName = "Solvarg/SkillConfig")]
public class SkillConfig : ScriptableObject
{
    [AllowNesting]
    [Label("技能Id")]
    public string skillId;
    [AllowNesting]
    [Label("技能释放类型")]
    public SkillShowPattern showPattern;
    [AllowNesting]
    [Label("技能名称")]
    public string skillName;
    [AllowNesting]
    [Label("技能描述")]
    public string skillDescription;
    [AllowNesting]
    [Label("技能特效")]
    public List<SkillEffectDisplayInfo> displayInfo;

 
    [AllowNesting]
    [Label("被击特效Id")]
    public string hitEfffectId;

}
