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
    }

    public override void OnInit(IFsm<ProcedureManager> fsm)
    {
        base.OnInit(fsm);
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
