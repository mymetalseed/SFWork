using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Buff信息
/// </summary>
public class SFAction_BuffInfo : SFAction_BaseAction
{
    public override void TrigAction()
    {
        GameObject.Destroy(owner.gameObject);
    }

    public void SetOwner(GameObject owner,GameObject target)
    {
        /*设置owner
        for (int i = 0; i < ses.Length; ++i)
        {
            ses[i].owner = owner;
            ses[i].buffInfo = this;
            ses[i].target = target;
        }
        */
    }
}
