using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCreature
{
    private string nickName;

    public override void InitRole(RoleInfo role)
    {
        base.InitRole(role);
    }

    public void LevelUp()
    {

    }

    public void AddExp(int expAdd) {
        this.CurrentExp += expAdd;
        //做经验值处理
        //比如升级
    }

}
