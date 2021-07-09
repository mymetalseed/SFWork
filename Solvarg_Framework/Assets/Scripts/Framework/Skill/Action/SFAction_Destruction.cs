using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 销毁物体专用
/// </summary>
public class SFAction_Destruction : SFAction_BaseAction
{
    public override void TrigAction()
    {
        Destroy(gameObject);
    }
}
