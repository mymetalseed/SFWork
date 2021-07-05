using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

/*
 * normalizedtime解释: 
 * animator所处的state播放完毕，如果未进入下一个state，
 * 且没有循环，则该state的normalizedtime会大于1（state末尾）
 * 或小于0（负数，倒播到开头处，speed为负数）；如果此时触发
 * 条件进入下一个state，则会由于normalizedtime不是1,或0，
 * 有一段时间延迟（1.xxx-->1或-0.xxx---->0）
 * 
 */

public delegate void NotifySkill();

public class StateMachine : StateMachineBehaviour
{
    bool IsLastTransition;
    bool IsCurTransition;
    AnimatorStateInfo LastStateInfo;
    Dictionary<AnimTrigState, List<NotifySkill>> skillDict = new Dictionary<AnimTrigState, List<NotifySkill>>();

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        IsCurTransition = animator.IsInTransition(layerIndex);

        if (!IsCurTransition)
        {
            if(stateInfo.normalizedTime % 1.0 < LastStateInfo.normalizedTime % 1.0)
            {
                //CastSkillEnd
                TrigAction(AnimTrigState.TrigEnd);
            }
        }

        ///当前状态在转移,但是上一帧没有在转移
        if(IsCurTransition && !IsLastTransition)
        {
            //CastSkillBegin
            TrigAction(AnimTrigState.TrigBegin);
        }

        if(!IsCurTransition && IsLastTransition)
        {
            //CastSkillEnd1
            TrigAction(AnimTrigState.TrigEnd);
        }

        IsLastTransition = IsCurTransition;
        LastStateInfo = stateInfo;

    }

    /// <summary>
    /// 执行
    /// </summary>
    /// <param name="state"></param>
    void TrigAction(AnimTrigState state)
    {
        if (skillDict.ContainsKey(state))
        {
            List<NotifySkill> list = skillDict[state];
            while (list.Count > 0)
            {
                NotifySkill ns = list[0];
                list.Remove(ns);
                ns?.Invoke();
            }
        }
    }

    public void RegisterCallback(AnimTrigState state,NotifySkill action)
    {
        List<NotifySkill> list;
        if (skillDict.ContainsKey(state))
        {
            list = skillDict[state];
            list.Add(action);
        }
        else
        {
            list = new List<NotifySkill>();
            list.Add(action);
            skillDict.Add(state, list);
        }
    }

    public void ClearAllCallbacks()
    {
        if (null == skillDict)
            return;
        List<NotifySkill> list;
        for(AnimTrigState i = AnimTrigState.TrigBegin; i <= AnimTrigState.TrigEnd; ++i)
        {
            if (skillDict.ContainsKey(i))
            {
                list = skillDict[i];
                list.Clear();
            }
        }
    }

}
