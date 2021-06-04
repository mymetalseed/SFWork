using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    }

    public override void OnLeave(ProcedureOwner fsm, bool isShutDown)
    {
        base.OnLeave(fsm, isShutDown);
        Debuger.LogError("离开预加载流程");
    }

    public override void OnUpdate(ProcedureOwner fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        Debuger.Log("预加载流程在更新呢");
    }
}
