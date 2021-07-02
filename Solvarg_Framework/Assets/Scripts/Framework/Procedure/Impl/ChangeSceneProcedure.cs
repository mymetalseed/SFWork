using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProcedureOwner = IFsm<ProcedureManager>;
using static Defines;

public class ChangeSceneProcedure : ProcedureBase
{

    private SceneConfig currentSc;

    public override void OnDestroy(ProcedureOwner fsm)
    {
        base.OnDestroy(fsm);
    }

    public async override void OnEnter(ProcedureOwner fsm)
    {
        base.OnEnter(fsm);
       
        string nextScene = SettingManager.Instance.GetString(MessageRouter.Scene_NextScene);

        EnumSceneName scName = (EnumSceneName)Enum.Parse(typeof(EnumSceneName), nextScene);

        currentSc = SingletonManager.Instance.GetSceneConfig(scName);

        await SingletonManager.Instance.Scene_EnterScene(scName);
        if (currentSc.Type == EnumSceneType.Tutorial.ToString())
        {
            //进入教程流程
            //ChangeState<TutorialProcedure>(fsm)
        }
        else
        {
            throw new System.Exception("抱歉,非法场景请求");
        }
    }

    public override void OnInit(ProcedureOwner fsm)
    {
        base.OnInit(fsm);
    }

    public override void OnLeave(ProcedureOwner fsm, bool isShutDown)
    {
        base.OnLeave(fsm, isShutDown);
    }

    public override void OnUpdate(ProcedureOwner fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

    }



}
