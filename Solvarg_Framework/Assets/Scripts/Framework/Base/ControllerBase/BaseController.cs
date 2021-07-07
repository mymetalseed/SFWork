using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllerType
{
    Animator,
    Skill,
    Weapon
}


public abstract class BaseController
{
    #region 参数
    public BaseCreature owner;
    #endregion
    abstract public void OnStart(BaseCreature role);
    abstract public void OnUpdate();
}
