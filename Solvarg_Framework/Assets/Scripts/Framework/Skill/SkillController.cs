using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : BaseController
{
    #region 参数
    bool _IsPlaying;
    public bool IsPlaying => (_IsPlaying);

    private bool isReady = true;
    public bool IsReady => (isReady);

    SkillType currentSkillType;

    public int _CurAnimAttackIndex = 1;
    public int MinAnimAttackIndex = 1;
    public int MaxAnimAttackIndex = 3;

    string curAnimName;
    string AttackPre="Base Layer.Attack";

    
    #endregion

    public override void OnStart(BaseCreature role)
    {
        
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    #region 攻击捕捉
    public void CastSkill(SkillType type)
    {
        if(!IsReady || owner.IsGetHit)
        {
            return;
        }

        currentSkillType = type;
        if(type== SkillType.eAttack)
        {
            if(_CurAnimAttackIndex > MaxAnimAttackIndex)
            {
                _CurAnimAttackIndex = MaxAnimAttackIndex;
            }
            curAnimName = AttackPre + _CurAnimAttackIndex.ToString();
        }
        SingletonManager.Instance.StartAnimation(owner,curAnimName,CastSkillReady,CastSkillBegin,CastSkillEnd,CastSkillEnd1);
    }

    void CastSkillReady()
    {
        Debuger.Log("技能准备");
        if (currentSkillType == SkillType.eAttack)
        {
            isReady = true;
        }
    }

    void CastSkillBegin()
    {
        _IsPlaying = true;
        Debuger.Log("技能开始");
        //普攻
        if (currentSkillType == SkillType.eAttack)
        {
            isReady = false;

            //面朝敌人
            _CurAnimAttackIndex++;
        }

        //加载特效
        //加载技能等
        
    }

    void CastSkillEnd1()
    {

    }

    void CastSkillEnd()
    {
        Debuger.Log("技能结束");
        if(currentSkillType == SkillType.eAttack)
        {
            _CurAnimAttackIndex = MinAnimAttackIndex;
            isReady = true; 
        }else if(currentSkillType == SkillType.eSkill)
        {

        }

        AnimatorStateInfo state = owner.Anim.GetCurrentAnimatorStateInfo(0);
        if(state.IsName("Base Layer.GetHit"))
        {

        }
        else
        {
            _IsPlaying = false;
        }
    }
    #endregion

}
