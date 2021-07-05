using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : Singleton<AnimatorManager>
{
    public void StartAnimation(AnimatorController animatorController,string animName, NotifySkill skillReady, NotifySkill SkillBegin, NotifySkill SkillEnd, NotifySkill SkillEnd1)
    {
        if (animName == "") return;

        animatorController.AnimInst.Anim.SetTrigger(animName);
        animatorController.skillReadyInst = skillReady;

        //先清除所有回调
        animatorController.StateInst.ClearAllCallbacks();
        animatorController.StateInst.RegisterCallback(AnimTrigState.TrigBegin,SkillBegin);
        animatorController.StateInst.RegisterCallback(AnimTrigState.TrigEnd,()=> {
            SkillEnd1?.Invoke();

            singletonManager.InvokeNextFrame(()=>{
                animatorController.StateInst.RegisterCallback(AnimTrigState.TrigEnd, SkillEnd);
            });
        });
    }

    #region Unity Callback
    public override void Awake()
    {
        base.Awake();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnGUI()
    {
        base.OnGUI();
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }
    #endregion
}
