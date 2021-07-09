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
        Destroy(gameObject);
    }

    public void SetOwner(GameObject owner,GameObject target)
    {
        SFAction_DataStore[] ses = gameObject.GetComponentsInChildren<SFAction_DataStore>();

        for (int i = 0; i < ses.Length; ++i)
        {
            ses[i].owner = owner;
            ses[i].buffInfo = this;
            ses[i].target = target;
        }
    }
}
