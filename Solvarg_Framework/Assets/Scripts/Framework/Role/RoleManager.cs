using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : Singleton<RoleManager>
{
    #region Params
    private List<RoleInfo> roleInfos;
    private Dictionary<string, RoleInfo> roleInfo_ID;
    private RoleInfo playerInfo;

    private List<BaseRole> currentRoleList;
    private Dictionary<string, BaseRole> currentRoleDict;
    #endregion

    #region 功能函数
    public void InitRole(List<RoleInfo> info)
    {
        this.roleInfos = info;
        roleInfo_ID = new Dictionary<string, RoleInfo>();
        foreach (RoleInfo role in info)
        {
            roleInfo_ID.Add(role.ID,role);
            Debuger.Log("添加角色信息(非实例化): " + role.DefaultName + " 阵营: " + role.playerSide.ToString());
            if(role.playerSide == PlayerSide.Player)
            {
                playerInfo = role;
            }
        }
    }

    public RoleInfo GetPlayerInfo()
    {
        return playerInfo;
    }

    /// <summary>
    /// 角色出生
    /// </summary>
    public void AddRole(BaseRole role)
    {
        currentRoleList.Add(role);
        if (currentRoleDict.ContainsKey(role.info.ID))
        {
            currentRoleDict[role.info.ID] = role;
        }
        else currentRoleDict.Add(role.info.ID, role);
    }

    public void RemoveRole(BaseRole role)
    {
        currentRoleList.Remove(role);
        if (currentRoleDict.ContainsKey(role.info.ID))
        {
            currentRoleDict.Remove(role.info.ID);
        }
    }

    /// <summary>
    /// 实例化新的角色,这里需要考虑实例化的时候给与什么参数
    /// 比如等级,位置
    /// </summary>
    /// <returns></returns>
    public BaseRole SpawnRole()
    {
        throw new Exception("暂未实现");
    }
    #endregion

    #region Unity Callback
    public override void Awake()
    {
        base.Awake();
        currentRoleList = new List<BaseRole>();
        currentRoleDict = new Dictionary<string, BaseRole>();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnGUI()
    {
        base.OnGUI();
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }
    #endregion
}
