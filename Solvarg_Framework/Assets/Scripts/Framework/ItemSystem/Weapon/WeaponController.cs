using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : BaseController
{
    public Weapon currentWeapon;

    #region Function
    /// <summary>
    /// 尝试释放武器
    /// </summary>
    public void TryReleaseWeapon()
    {
        currentWeapon = null;
        //TODO: 执行release后的操作,比如播放武器被夺去走的动画

    }
    #endregion

    #region UnityCallback
    public override void OnStart(BaseCreature role)
    {
    }

    public override void OnUpdate()
    {
    }
    #endregion
}
