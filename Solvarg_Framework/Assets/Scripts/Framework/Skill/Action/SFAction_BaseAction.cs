using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFAction_BaseAction : MonoBehaviour
{
    [HideInInspector]
    public TriggerType trigType;
    [HideInInspector]
    public float duration;
    float startTime = 0f;
    bool isTriggered = false;

    private void Start()
    {
        if(trigType == TriggerType.eAuto)
        {
            startTime = Time.time;
            isTriggered = true;
        }
    }

    /// <summary>
    /// 条件触发
    /// </summary>
    public virtual void OnStart()
    {
        if(trigType == TriggerType.eCondition)
        {
            startTime = Time.time;
            isTriggered = true;
        }
    }

    protected virtual void Update()
    {
        if (!isTriggered)
            return;
        if(Time.time - startTime >= duration)
        {
            isTriggered = false;

        }
    }

    /// <summary>
    /// 执行Action
    /// </summary>
    public virtual void TrigAction()
    {

    }

    /// <summary>
    /// 获取当前对象上的数据缓存
    /// </summary>
    /// <returns></returns>
    public SFAction_DataStore GetDataStore()
    {
        SFAction_DataStore ds = gameObject.GetComponent<SFAction_DataStore>();
        return ds;
    }
}
