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
    protected QuestBase(QuestInfo info) {
        this.info = info;
        if (info.PreConditionType == ConditionType.Event.ToString())
        {
            preConditionType = ConditionType.Event;
        }

        if(info.ProcConditionType == ConditionType.Event.ToString())
        {
            preConditionType = ConditionType.Event;
        }

        Start();
    }
    protected QuestBase() { }

    #region 参数
    protected ConditionType preConditionType;
    protected ConditionType procConditionType;

    private QuestInfo info;
    public QuestInfo Info
    {
        get
        {
            return info;
        }
    }

    private QuestStatus currentStatus;
    public QuestStatus CurrentStatus {
        get {
            return currentStatus;
        }
    }
    #endregion

    protected virtual void Start()
    {
        currentStatus = QuestStatus.Hide;
        PreCondition();
    }

    /// <summary>
    /// 任务完成后执行
    /// </summary>
    public virtual void Reward() {
        //在这里判断失败还是成功
        currentStatus = QuestStatus.Complete;
    }
    /// <summary>
    /// 任务先验
    /// </summary>
    public virtual void PreCondition() {
        
        /*
        if (preConditionType == ConditionType.Event)
        {
            SingletonManager.Instance.Message_Subscribe(Info.PreConditionParam, PreConditionDone);
        }
        */
        
    }

    /// <summary>
    /// 任务过程验
    /// </summary>
    public virtual void ProcCondition() {
        currentStatus = QuestStatus.Processing;
        /*
        if (procConditionType == ConditionType.Event)
        {
            SingletonManager.Instance.Message_Subscribe(Info.ProcConditionParam, ProcConditionDone);
        }
        */
    }

    /// <summary>
    /// 放弃任务
    /// </summary>
    public virtual void DiscardQuest() {
        currentStatus = QuestStatus.Discard;
    }

    public virtual async void PreConditionDone(Message message)
    {
        /*
        SingletonManager.Instance.Message_UnSubscribe(Info.PreConditionParam, PreConditionDone);
        await OnPreConditionComplete(message);
        */
        currentStatus = QuestStatus.Prepare;
        ProcCondition();
    }

    public virtual async void ProcConditionDone(Message message)
    {
        /*
        SingletonManager.Instance.Message_UnSubscribe(Info.ProcConditionParam, ProcConditionDone);
        await OnProcConditionComplete(message);
        */
    }

}
