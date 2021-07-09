using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFAction_BuffSpawnWorld : SFAction_BaseAction
{
    SFAction_DataStore se;

    [HideInInspector]
    private GameObject effectSpawnInst;
    public string effectId;

    [HideInInspector]
    public float effectDestroyDelay;

    [HideInInspector]
    public float effectScale = 1;

    public async override void TrigAction()
    {
        se = GetComponent<SFAction_DataStore>();

        GameObject defencer = se.target;
        BaseCreature defencerBaseCreature = defencer.GetComponent<BaseCreature>();

        //spawn effectTODO,这里要加入effect的路径
        GameObject effect = await SingletonManager.Instance.InstantiateAsync(effectId);

        effect.transform.localScale = Vector3.one * effectScale;
        SFAction_Destruction des = effect.GetComponent<SFAction_Destruction>();
        if (null != des)
        {
            des.duration = effectDestroyDelay;
            des.OnStart();
        }

        effect.transform.position = defencerBaseCreature.ClosestHitPoint;
    }

}
