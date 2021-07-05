using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimatorController : BaseController
{
    #region 参数
    public NotifySkill skillReadyInst;
    private BaseCreature _animInst;
    public BaseCreature AnimInst=>(_animInst);
    private StateMachine stateInst;
    /// <summary>
    /// StateMachine有时候可能因为在加载的原因无法在Start获取到
    /// </summary>
    public StateMachine StateInst
    {
        get
        {
            if (stateInst == null)
            {
                stateInst = owner.Anim.GetBehaviour<StateMachine>();
            }
            return stateInst;

        }
    }
    #endregion

    public override void OnStart(BaseCreature animInst)
    {
        this._animInst = animInst;
    }

    public void EventSkillReady()
    {
        skillReadyInst();
    }

    public void EventAnimBegin()
    {

    }

    public void EventAnimEnd(int id)
    {
        SkillStateID _id = (SkillStateID)id;

        switch (_id)
        {
            case SkillStateID.eGetHit:
                {
                    Debuger.LogError("受击");
                    /*
                    if (AnimInst.info.playerSide == PlayerSide.Enemy)
                    {
                        
                    }
                    */
                    break;
                }
        }
    }

    public override void OnUpdate()
    {
        throw new NotImplementedException();
    }
}
