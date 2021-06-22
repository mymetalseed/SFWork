using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRole : MonoBehaviour
{
    private EnumRoleState roleState;
    public EnumRoleState RoleState => (roleState);

    #region 属性参数
    [HideInInspector]
    public int level;
    public RoleInfo info;

    /// <summary>
    /// 是否已经初始化角色信息
    /// </summary>
    private bool isInitial = false;

    //0保存BaseHP,1保存成长比率,2保存成长比率常数
    private float[] hpEnhanceRate;
    private float[] actionPowerEnhanceRate;
    private float[] mpPowerEnhanceRate;
    private float[] attackEnhanceRate;
    private float[] expEnhanceRate;

    [HideInInspector]
    public int CurrentHp;
    [HideInInspector]
    public int CurrentMp;
    [HideInInspector]
    public int CurrentAction;
    [HideInInspector]
    public int CurrentExp;


    public virtual int GetCurrentMaxHp
    {
        get
        {
            return (int)(hpEnhanceRate[0] * (level * hpEnhanceRate[1]) + level * hpEnhanceRate[2]);
        }
    }

    public virtual int GetCurrentMaxMp
    {
        get
        {
            return (int)(mpPowerEnhanceRate[0] * (level * mpPowerEnhanceRate[1]) + level * mpPowerEnhanceRate[2]);
        }
    }

    public virtual int GetCurrentMaxAction
    {
        get
        {
            return (int)(actionPowerEnhanceRate[0] * (level * actionPowerEnhanceRate[1]) + level * actionPowerEnhanceRate[2]);
        }
    }
    
    public virtual int GetCurrentMaxAttack
    {
        get
        {
            return (int)(attackEnhanceRate[0] * (level * attackEnhanceRate[1]) + level * attackEnhanceRate[2]);
        }
    }

    public virtual int GetCurrentMaxExp
    {
        get
        {
            return (int)(expEnhanceRate[0] * (level * expEnhanceRate[1]) + level * expEnhanceRate[2]);

        }
    }


    #endregion

    #region 等级函数

    public virtual void InitRole(RoleInfo role)
    {
        this.info = role;
        this.level = 1;
        this.roleState = EnumRoleState.Idle;
        this.hpEnhanceRate = dealRate(role.BaseHP);
        this.mpPowerEnhanceRate = dealRate(role.BaseMP);
        this.attackEnhanceRate = dealRate(role.BaseAttack);
        this.actionPowerEnhanceRate = dealRate(role.BaseActionPower);
        this.expEnhanceRate = dealRate(role.BaseExp);

        this.CurrentAction = GetCurrentMaxAction;
        this.CurrentHp = GetCurrentMaxHp;
        this.CurrentMp = GetCurrentMaxMp;
        this.CurrentExp = 0;
        isInitial = true;
    }


    private static float[] dealRate(string enhanceData)
    {
        string[] first = enhanceData.Split('|');

        string[] second = first[1].Replace('[', '0').Replace(']','0').Split(',');

        float[] res = { Convert.ToSingle(first[0]), Convert.ToSingle(second[0]), Convert.ToSingle(second[1]) };
        return res;
    }
    #endregion



    #region UnityCallBack
    protected virtual void Awake()
    {
        isInitial = false;
        SingletonManager.Instance.AddRole(this);
    }

    protected virtual void OnDestroy()
    {
        SingletonManager.Instance.RemoveRole(this);
    }

    protected virtual void Update()
    {

    }
    #endregion



    #region RoleFunction
    /// <summary>
    /// 世界物体被碰撞触发时调用的函数
    /// defender是自己
    /// </summary>
    public virtual void Excute(BaseRole attacker)
    {

    }

    public virtual void Die()
    {

    }
    #endregion
}
