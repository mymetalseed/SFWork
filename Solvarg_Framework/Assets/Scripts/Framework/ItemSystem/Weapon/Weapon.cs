using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ItemBase
{
    private WeaponInfo weaponInfo;
    public WeaponInfo WeaponInfo => (weaponInfo);

    public BaseCreature owner;

    public void SetWeaponInfo(WeaponInfo info)
    {
        this.weaponInfo = info;
    }

    /// <summary>
    /// 丢弃武器
    /// </summary>
    public void Release()
    {
        //ItemModel.transform.parent;
        Debuger.LogError("释放武器");
        ItemModel.transform.parent = SingletonManager.Instance.GetWorldTrans;
    }

    public override void Excute()
    {

    }
}
