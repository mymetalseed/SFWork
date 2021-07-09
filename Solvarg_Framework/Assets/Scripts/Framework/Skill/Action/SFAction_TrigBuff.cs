using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFAction_TrigBuff : SFAction_BaseAction
{
    private string constBuffPath = "";
    public string buffID;

    public async override void TrigAction()
    {
        SFAction_DataStore ae = GetDataStore();

        //实例化Buff

        string path = constBuffPath + buffID+".prefab";

        GameObject buffInst = await SingletonManager.Instance.InstantiateAsync(path);

        //我们需要一个SFAction_BuffInfo
        //我们需要告诉Buff,谁是attacker,谁是defender
        SFAction_BuffInfo buffInfo = buffInst.GetComponent<SFAction_BuffInfo>();

        //攻击者 : 即这个技能持有者
        //防御者 : 即这个技能碰到的合法敌人
        buffInfo.SetOwner(ae.owner,ae.target);
    }
}
