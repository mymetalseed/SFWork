using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum QuestStatus
{
    Hide,   //不在当前可执行/接收任务列表中,
    Prepare,    //可接受
    Processing, //已接收,在执行
    Discard,    //丢弃
    Fail,       //执行失败
    Complete    //执行成功
}

public enum ConditionType
{
    None,
    Event
}

public abstract class QuestBase
{

    public QuestBase(QuestInfo info) {
        if (info.PreConditionType == ConditionType.Event.ToString())
        {
            preConditionType = ConditionType.Event;
        }

        if(info.ProcConditionType == ConditionType.Event.ToString())
        {
            preConditionType = ConditionType.Event;
        }
    }
    private QuestBase() { }

    #region 参数
    protected ConditionType preConditionType;
    protected ConditionType procConditionType;

    public virtual QuestInfo Info { get; }

    public virtual QuestStatus currentStatus { get; }
    #endregion
    /// <summary>
    /// 任务完成后执行
    /// </summary>
    public virtual void Reward() { }
    /// <summary>
    /// 任务先验
    /// </summary>
    private void PreCondition() {
        if (preConditionType == ConditionType.Event)
        {
            SingletonManager.Instance.Message_Subscribe(Info.PreConditionParam, PreConditionDone);
        }
    }

    /// <summary>
    /// 任务过程验
    /// </summary>
    private void ProcCondition() {
        if (procConditionType == ConditionType.Event)
        {
            SingletonManager.Instance.Message_Subscribe(Info.ProcConditionParam, ProcConditionDone);
        }
    }

    /// <summary>
    /// 放弃任务
    /// </summary>
    public virtual void DiscardQuest() { }

    private async void PreConditionDone(Message message)
    {
        SingletonManager.Instance.Message_UnSubscribe(Info.PreConditionParam, PreConditionDone);
        await OnPreConditionComplete(message);
    }

    private async void ProcConditionDone(Message message)
    {
        SingletonManager.Instance.Message_UnSubscribe(Info.ProcConditionParam, ProcConditionDone);
        await OnProcConditionComplete(message);
    }

    /// <summary>
    /// 当任务进入待检测状态时触发
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async virtual Task OnPreConditionComplete(Message message)
    {

    }

    /// <summary>
    /// 当任务进入执行时触发
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async virtual Task OnProcConditionComplete(Message message)
    {

    }
}
