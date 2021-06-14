using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using ProcedureOwner = IFsm<ProcedureManager>;

public class PreloadProcedure : ProcedureBase
{
    private bool isDone = false;

    public override void OnInit(ProcedureOwner fsm)
    {
        base.OnInit(fsm);
        isDone = false;
        Debuger.Log("初始化预加载流程");
    }

    public async override void OnEnter(ProcedureOwner fsm)
    {
        base.OnEnter(fsm);
        Debuger.Log("进入预加载流程,进入菜单前的检查流程");
        //加载过场面板
        await SingletonManager.Instance.LoadProgressUI();
        SingletonManager.Instance.OpenProgressUI();
        SingletonManager.Instance.ProgressUIInstance.NotifyConfigProgress(1,2);

        //加载MainCamera


        //加载DialogUI
        SingletonManager.Instance.ProgressUIInstance.SetProgressToolTip("开始加载配置...");
        UIConfig dialogUI = SingletonManager.Instance.GetUIConfig(Defines.EnumUIName.Dialog);
        GameObject dialog = await SingletonManager.Instance.InstantiateAsync(dialogUI.Path);
        SingletonManager.Instance.SetDialog(dialog.GetComponent<UIDialog>());
        SingletonManager.Instance.ProgressUIInstance.NotifyConfigProgress(2,2);


        ChangeState<MenuProcedure>(fsm);
    }

    public override void OnLeave(ProcedureOwner fsm, bool isShutDown)
    {
        base.OnLeave(fsm, isShutDown);
        Debuger.LogError("离开预加载流程");
    }

    public override void OnUpdate(ProcedureOwner fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        if (Input.GetKeyDown(KeyCode.O))
        {
            SingletonManager.Instance.OpenDialog("测试","测试啦","关闭","打开",()=> { Debuger.LogError("测试关闭"); });
        }

        
    }



}
