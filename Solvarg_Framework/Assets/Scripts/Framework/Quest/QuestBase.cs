using System.Collections;
using System.Collections.Generic;
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

public abstract class QuestBase
{
    public QuestBase(QuestInfo info) { }
    private QuestBase() { }

    public virtual QuestInfo Info { get; }

    public virtual QuestStatus currentStatus { get; }

    /// <summary>
    /// 任务完成后执行
    /// </summary>
    public virtual void Reward() { }
    /// <summary>
    /// 任务先验
    /// </summary>
    public virtual void PreCondition() { }

    /// <summary>
    /// 任务过程验
    /// </summary>
    public virtual void ProcCondition() { }

    /// <summary>
    /// 放弃任务
    /// </summary>
    public virtual void DiscardQuest() { }
}
