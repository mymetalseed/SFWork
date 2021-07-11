using SolvargSkill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFAction_BaseAction 
{
    float startTime = 0f;
    bool isTriggered = false;

    [HideInInspector]
    public GameObject owner;

    [HideInInspector]
    public GameObject target;

    [HideInInspector]
    public SFAction_SkillInfo skillInfo;
    [HideInInspector]
    public SFAction_BuffInfo buffInfo;


    private void Start()
    {
        /*
        if(dataNode.trigType == TriggerType.eAuto)
        {
            startTime = Time.time;
            isTriggered = true;
        }
        */
    }

    /// <summary>
    /// 条件触发
    /// </summary>
    public virtual void OnStart()
    {
        /*
        if(dataNode.trigType == TriggerType.eCondition)
        {
            startTime = Time.time;
            isTriggered = true;
        }
        */
    }

    protected virtual void Update()
    {
        /*
        if (!isTriggered)
            return;
        if(Time.time - startTime >= dataNode.duration)
        {
            isTriggered = false;

        }
        */
    }

    /// <summary>
    /// 执行Action
    /// </summary>
    public virtual void TrigAction()
    {

    }

}
