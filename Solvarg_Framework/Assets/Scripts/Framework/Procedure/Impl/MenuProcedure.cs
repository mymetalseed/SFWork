using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuProcedure : ProcedureBase
{
    public override void OnInit(IFsm<ProcedureManager> fsm)
    {
        base.OnInit(fsm);
    }

    public override void OnEnter(IFsm<ProcedureManager> fsm)
    {
        base.OnEnter(fsm);
        Debuger.Log("进入菜单流程");
    }

    public override void OnLeave(IFsm<ProcedureManager> fsm, bool isShutDown)
    {
        base.OnLeave(fsm, isShutDown);
    }

    public override void OnUpdate(IFsm<ProcedureManager> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
    }
}
