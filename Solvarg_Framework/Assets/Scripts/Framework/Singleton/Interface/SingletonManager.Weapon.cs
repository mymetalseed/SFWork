using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 通过武器Id获取武器实体
    /// </summary>
    /// <param name="wid"></param>
    /// <returns></returns>
    public async Task<Weapon> GetWeaponByWid(int wid)
    {
        return await weaponManager.GetWeaponByWid(wid);
    }

    /// <summary>
    /// 将武器挂载到角色身上
    /// </summary>
    /// <param name="role"></param>
    /// <param name="weapon"></param>
    public void LinkToRole(BaseCreature role, Weapon weapon)
    {
        weaponManager.LinkToRole(role,weapon);
    }

    /// <summary>
    /// 通过武器id生成武器并挂载到角色身上
    /// </summary>
    /// <param name="role"></param>
    /// <param name="wid"></param>
    /// <returns></returns>
    public async Task<Weapon> LinkWeaponToRole(BaseCreature role, int wid)
    {
        return await weaponManager.LinkWeaponToRole(role,wid);
    }

}
