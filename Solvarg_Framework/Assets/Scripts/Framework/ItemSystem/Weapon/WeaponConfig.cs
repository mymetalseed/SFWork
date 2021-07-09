using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;

[Serializable]
public class WeaponInfo
{
    [AllowNesting]
    [Label("武器名称")]
    public string weaponName;
    [AllowNesting]
    [Label("武器Id")]
    public int weaponId;
    [AllowNesting]
    [Label("对应物品Id")]
    public string itemId;
    [AllowNesting]
    [Label("武器类型")]
    public WeaponType weaponType;

    [AllowNesting]
    [Label("挂点名称")]
    public string targetSpineNode;
    [AllowNesting]
    [Label("武器局部坐标")]
    public Vector3 weaponPos;
    [AllowNesting]
    [Label("武器局部角度")]
    public Vector3 weaponRot;
    [AllowNesting]
    [Label("武器局部缩放")]
    public Vector3 weaponScale;

    [AllowNesting]
    [Label("武器属性")]
    public WeaponAttrInfo weaponAttr;
}

[Serializable]
public class WeaponAttrInfo
{
    //武器对属性的叠加
    [AllowNesting]
    [Label("生命值加成")]
    public int Hp;
    [AllowNesting]
    [Label("蓝量加成")]
    public int Mp;
    [AllowNesting]
    [Label("行动力加成")]
    public int ActionPower;
    [AllowNesting]
    [Label("攻击加成")]
    public int Attack;
}

[CreateAssetMenu(fileName ="WeaponConfig",menuName ="Solvarg/Weapon")]
public class WeaponConfig : ScriptableObject
{
    [Foldout("武器列表")]
    [Label("武器列表")]
    [ReorderableList]
    public List<WeaponInfo> weapons;
}
