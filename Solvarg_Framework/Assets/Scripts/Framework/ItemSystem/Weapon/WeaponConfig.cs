using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WeaponInfo
{
    public string weaponName;
    public int weaponId;
    public string itemId;
    public WeaponType weaponType;

    public Vector3 weaponPos;
    public Vector3 weaponRot;
    public Vector3 weaponSacale;

    public string targetSpineNode;

    public WeaponAttrInfo weaponAttr;
}

[Serializable]
public class WeaponAttrInfo
{
    //武器对属性的叠加
    public int Hp;
    public int Mp;
    public int ActionPower;
    public int Attack;
}

[CreateAssetMenu(fileName ="WeaponConfig",menuName ="Solvarg/Weapon")]
public class WeaponConfig : ScriptableObject
{
    public List<WeaponInfo> weapons;
}
