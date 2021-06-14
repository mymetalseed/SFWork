using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProcedureOwner = IFsm<ProcedureManager>;

public class ChangeSceneProcedure : ProcedureBase
{
    public override void OnDestroy(ProcedureOwner fsm)
    {
        base.OnDestroy(fsm);
    }

    public override void OnEnter(ProcedureOwner fsm)
    {
        base.OnEnter(fsm);
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
