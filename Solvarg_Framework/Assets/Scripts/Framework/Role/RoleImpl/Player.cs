using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCreature
{
    private string nickName;

    public override void InitRole(RoleInfo role)
    {
        base.InitRole(role);
        AnimatorController anim = RegisterController(ControllerType.Animator) as AnimatorController;
        ActionController action = RegisterController(ControllerType.Action) as ActionController;
        WeaponController weapon = RegisterController(ControllerType.Weapon) as WeaponController;

        //配置最大连击次数(根据动画来决定)
        action.MaxAnimAttackIndex = 2;
    }

    public void LevelUp()
    {

    }

    public void AddExp(int expAdd) {
        this.CurrentExp += expAdd;
        //做经验值处理
        //比如升级
    }

    #region UNITY_callback
    protected override void Awake()
    {
        base.Awake();

    }

    protected override void Update()
    {
        base.Update();

    }
    #endregion
}
