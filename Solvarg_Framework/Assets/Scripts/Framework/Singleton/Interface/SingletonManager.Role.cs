using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SingletonManager
{
    #region 所有角色相关
    public void InitRoleInfo(List<RoleInfo> info)
    {
        roleManager.InitRole(info);
    }

    public RoleInfo GetPlayerInfo()
    {
        return roleManager.GetPlayerInfo();
    }
    #endregion

    #region Player相关
    /// <summary>
    /// 角色系统初始化
    /// </summary>
    public void InitPlayer()
    {
        playerManager.InitPlayer();
    }
    #endregion
}
