using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EventQuest : QuestBase
{
    public EventQuest(QuestInfo info) : base(info)
    {
        
    }

    public override void DiscardQuest()
    {
        base.DiscardQuest();
    }

    public override void PreCondition()
    {
        SingletonManager.Instance.Message_Subscribe(Info.PreConditionParam, PreConditionDone);
        base.PreCondition();
    }

    public override void PreConditionDone(Message message)
    {
        SingletonManager.Instance.Message_UnSubscribe(Info.PreConditionParam, PreConditionDone);
        base.PreConditionDone(message);
    }

    public override void ProcCondition()
    {
        base.ProcCondition();
        Debuger.Log("任务接取成功");
        SingletonManager.Instance.Message_Subscribe(Info.ProcConditionParam, ProcConditionDone);

    }

    public override void ProcConditionDone(Message message)
    {
        base.ProcConditionDone(message);

        //归约.
        //1.杀怪统一由BasePlayer发送,参数内部加怪物名字,然后这里接收,统计数量触发任务完成
        //2.直接任务完成,即走到对应地点即可完成任务,后续触发事件可以在这里进行触发
        //3.其他任务类型一致
        //只有触发Reward才算任务完成
        //至于如何触发事件,任务完成后会抛出一个事件,如果事件池中注册了对应事件,则开始执行相应的事件表现
        
        
    }

    public override void Reward()
    {
        SingletonManager.Instance.Message_UnSubscribe(Info.ProcConditionParam, ProcConditionDone);
        base.Reward();
    }

    protected override void Start()
    {
        base.Start();

    }
}
