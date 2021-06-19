using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCreature : BaseRole
{
    #region 参数
    public Vector2[] AnimPerArray;
    public Vector2[] AnimSkillPerArray;
    protected Animator _Anim;
    public Animator Anim => (_Anim);
    private CharacterController characterCtrl;

    public CharacterController CharacCtrl => (characterCtrl);
    private float playerraidus;
    public float PlayerRadius => (playerraidus);
    #endregion

    protected override void Awake()
    {
        base.Awake();
        characterCtrl = GetComponent<CharacterController>();
        _Anim = GetComponent<Animator>();
    }

    public override void InitRole(RoleInfo role)
    {
        base.InitRole(role);
    }
}
