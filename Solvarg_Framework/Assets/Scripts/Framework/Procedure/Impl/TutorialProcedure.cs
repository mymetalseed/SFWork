using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialProcedure : ProcedureBase
{
    public override void OnDestroy(IFsm<ProcedureManager> fsm)
    {
        base.OnDestroy(fsm);
    }

    public override void OnEnter(IFsm<ProcedureManager> fsm)
    {
        base.OnEnter(fsm);
        Debuger.LogError("进入教程流程");
        SingletonManager.Instance.Message_Subscribe(MessageRouter.DialogueChatDone, ChatDone);
    }

    public override void OnInit(IFsm<ProcedureManager> fsm)
    {
        base.OnInit(fsm);
    }

    public override void OnLeave(IFsm<ProcedureManager> fsm, bool isShutDown)
    {
        base.OnLeave(fsm, isShutDown);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.DialogueChatDone, ChatDone);
    }

    public override void OnUpdate(IFsm<ProcedureManager> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //尝试给角色添加武器月刃
            SingletonManager.Instance.LinkWeaponToRole(SingletonManager.Instance.PlayerInst, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //尝试给角色添加武器初始之刃
            SingletonManager.Instance.LinkWeaponToRole(SingletonManager.Instance.PlayerInst, 1);
        }

    }

    private void ChatDone(Message message)
    {
        Debuger.Log("接收到了");
        Debuger.Log(message["param"]);
        SingletonManager.Instance.Enable3rdCamera();
        SingletonManager.Instance.StartMove();
    }

}
