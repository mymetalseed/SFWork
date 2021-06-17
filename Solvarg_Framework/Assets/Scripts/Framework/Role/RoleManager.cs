using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : Singleton<RoleManager>
{
    #region Params
    private List<RoleInfo> roleInfos;
    private Dictionary<string, RoleInfo> roleInfo_ID;
    private RoleInfo playerInfo;
    #endregion

    #region 功能函数
    public void InitRole(List<RoleInfo> info)
    {
        this.roleInfos = info;
        roleInfo_ID = new Dictionary<string, RoleInfo>();
        foreach (RoleInfo role in info)
        {
            roleInfo_ID.Add(role.ID,role);
            Debuger.Log("添加角色: " + role.DefaultName + " 阵营: " + role.playerSide.ToString());
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

    #endregion

    #region Unity Callback
    public override void Awake()
    {
        base.Awake();
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
