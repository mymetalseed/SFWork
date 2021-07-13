using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tools;

public class SFActionDamage_BindOwner : SFAction_BaseAction
{
    public SFAction_TrigBuff trigBuffInst;

    [HideInInspector]
    public string socketName;

    [HideInInspector]
    public Vector3 offSet;

    [HideInInspector]
    public Vector3 offRot;

    bool isTriggered = false;

    BoxCollider bc;
    Animator anim;

    float startCollidePercent;
    float endCollidePercent;

    BaseCreature bp;

    List<BaseCreature> baList;

    AnimatorStateInfo asi;
    float curPer;
    float lastPer;


    private void Awake()
    {
        baList = new List<BaseCreature>();
    }

    public override void TrigAction()
    {
        base.TrigAction();

        Transform socket = GameObjectTools.FindTheChild(owner,socketName);

        if (socket == null)
        {
            socket = owner.transform;
        }

        owner.transform.parent = socket.transform;
        owner.transform.localPosition = offSet;
        owner.transform.localRotation = Quaternion.Euler(offRot);

        bc = owner.GetComponent<BoxCollider>();
        anim = owner.GetComponent<Animator>();

        if(anim == null)
        {
            Debuger.LogError("Error Logic");
            return;
        }

        bp = owner.GetComponent<BaseCreature>();

        string skillName = "abc";

        isTriggered = true;
    }

    protected override void Update()
    {
        base.Update();
        if (!isTriggered)
        {
            return;
        }

        if(baList.Count > 0)
        {
            BaseCreature ba = baList[0];
            baList.Remove(ba);
            target = ba.gameObject;

            //trig Buff -> 实例化我们的buff
            trigBuffInst.OnStart();
        }

        if (anim.IsInTransition(0))
            return;

        //判断是否需要开启碰撞器
        asi = anim.GetCurrentAnimatorStateInfo(0);

        curPer = asi.normalizedTime % 1.0f;
        if(curPer >= startCollidePercent && lastPer < startCollidePercent)
        {
            bc.enabled = true;
        }else if (curPer > endCollidePercent && lastPer <= endCollidePercent)
        {
            bc.enabled = false;
            GameObject.Destroy(owner.gameObject);
        }

        lastPer = curPer;
    }

    private void OnTriggerEnter(Collider other)
    {
        //这里写受击
        BaseCreature ba = other.gameObject.GetComponent<BaseCreature>();
        if (ba == null)
        {
            return;
        }
        else
        {
            //根据阵营来执行对应的操作
        }
    }
}
