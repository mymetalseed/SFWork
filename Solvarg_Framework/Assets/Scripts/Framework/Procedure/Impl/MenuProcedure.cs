using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuProcedure : ProcedureBase
{

    public static string Header = "Menu";
    string action;
    private bool isInStart = false;

    public override void OnInit(IFsm<ProcedureManager> fsm)
    {
        base.OnInit(fsm);
        isInStart = false;
    }

    public async override void OnEnter(IFsm<ProcedureManager> fsm)
    {
        base.OnEnter(fsm);
        Debuger.Log("进入菜单流程");
        
        await SingletonManager.Instance.EnterScene(Defines.EnumSceneName.Menu);
        
    }

    public override void OnLeave(IFsm<ProcedureManager> fsm, bool isShutDown)
    {
        base.OnLeave(fsm, isShutDown);
    }

    public override void OnUpdate(IFsm<ProcedureManager> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        if (SettingManager.Instance.GetBool(MessageRouter.Menu_StartTutorial))
        {
            SettingManager.Instance.SetBool(MessageRouter.Menu_StartTutorial,false);
            OnStartGame(fsm);
        }
    }

    /// <summary>
    /// 开始游戏,如果有冷却在这里加
    /// </summary>
    private void OnStartGame(IFsm<ProcedureManager> fsm)
    {
        Debuger.LogError("从零开始游戏");
        SettingManager.Instance.SetString(MessageRouter.Scene_NextScene,Defines.EnumSceneName.Tutorial.ToString());
        ChangeState<ChangeSceneProcedure>(fsm);
    }


}
