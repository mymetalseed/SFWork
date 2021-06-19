using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SingletonManager
{
    #region 所有角色相关
    /// <summary>
    /// 初始化角色信息配置
    /// </summary>
    /// <param name="info"></param>
    public void InitRoleInfo(List<RoleInfo> info)
    {
        roleManager.InitRole(info);
    }

    /// <summary>
    /// 获取主角信息
    /// </summary>
    /// <returns></returns>
    public RoleInfo GetPlayerInfo()
    {
        return roleManager.GetPlayerInfo();
    }

    /// <summary>
    /// 添加Role
    /// </summary>
    /// <param name="role"></param>
    public void AddRole(BaseRole role)
    {
        roleManager.AddRole(role);
    }

    /// <summary>
    /// 移除Role
    /// </summary>
    /// <param name="role"></param>
    public void RemoveRole(BaseRole role)
    {
        roleManager.RemoveRole(role);
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
