using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRole : MonoBehaviour
{
    private EnumRoleState roleState;
    public EnumRoleState RoleState => (roleState);

    #region UnityCallBack
    private void Awake()
    {
        
    }
    #endregion

}
