using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 开始播放一个动画
    /// </summary>
    /// <param name="animatorController"></param>
    /// <param name="animName"></param>
    /// <param name="skillReady"></param>
    /// <param name="SkillBegin"></param>
    /// <param name="SkillEnd"></param>
    /// <param name="SkillEnd1"></param>
    public void StartAnimation(AnimatorController animatorController, string animName, NotifySkill skillReady, NotifySkill SkillBegin, NotifySkill SkillEnd, NotifySkill SkillEnd1)
    {
        animatorManager.StartAnimation(animatorController, animName, skillReady, SkillBegin, SkillEnd, SkillEnd1);
    }

    /// <summary>
    /// 从角色身上开启一个动画(前提该角色已经注册了控制器)
    /// </summary>
    /// <param name="baseCreature"></param>
    /// <param name="animName"></param>
    /// <param name="skillReady"></param>
    /// <param name="SkillBegin"></param>
    /// <param name="SkillEnd"></param>
    /// <param name="SkillEnd1"></param>
    public void StartAnimation(BaseCreature baseCreature,string animName, NotifySkill skillReady, NotifySkill SkillBegin, NotifySkill SkillEnd, NotifySkill SkillEnd1)
    {
        AnimatorController ac = baseCreature[ControllerType.Animator] as AnimatorController;
        if (ac != null)
        {
            StartAnimation(ac, animName, skillReady, SkillBegin, SkillEnd, SkillEnd1);
        }
    }

}
