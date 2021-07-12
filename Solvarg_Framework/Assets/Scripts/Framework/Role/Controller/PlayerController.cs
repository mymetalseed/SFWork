using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerController
{
    PlayerManager playerManager;

    #region 参数
    Animator anim;
    Player player;
    Camera camera;

    string _idleName;

    private bool isActive;
    /// <summary>
    /// 角色是否允许运动,或其他操作
    /// </summary>
    public bool IsActive=>(isActive);
    float horizontal;
    float vertical;
    float s1;
    public float speedMulti=3.0f;

    public LayerMask groundMask = LayerMask.NameToLayer("Ground");

    private bool _isGround;
    public bool isGround => _isGround && Mathf.Approximately(rigid.velocity.y, 0);

    private Rigidbody rigid;
    public Rigidbody Rigid => (rigid);

    private Collider collider;
    public Collider Collider => (collider);
    #endregion

    public PlayerController(PlayerManager pm)
    {
        this.playerManager = pm;
        isActive = false;
    }

    public void OnInit()
    {
        player = playerManager.GetPlayer;
        anim = player.Anim;
        camera = playerManager.GetCamera;
        rigid = player.Rigid;
        collider = player.Collider;

        isActive = false;
    }

    public void StartControl()
    {
        isActive = true;
    }

    public void StopConrtol()
    {
        isActive = false;
    }

    public void LateUpdate()
    {
        if (!CanMove()) return;
        
    }

    public void FixedUpdate()
    {
        if (!CanMove()) return;
        CheckGround();
    }

    public void Update()
    {
        anim.SetFloat(_idleName, rigid.velocity.magnitude);

        //#普通攻击
        /*
        if (InputData.HasEvent(InputEvents.Attack))
        {
            (player[ControllerType.Action] as ActionController)
                .CastSkill(SkillType.eAttack);
        }
        */
    }

    private void CheckGround()
    {
        float length = 0.02f;
        //_isGround = rigid.velocity.y > 0 ? false : Physics.Raycast(player.transform.position + length * Vector3.up, Vector3.down, length * 2, groundMask);
    }

    /// <summary>
    /// 检测是否可以移动,如果可以,根据当前输入缓冲中的数据进行移动
    /// </summary>
    public void CheckMove(string idleName = "IdleAndRun")
    {
        if (!CanMove()) return;
        SetPlayerAnimMovePam(idleName);
    }

    bool CanMove()
    {
        if (!isActive) return false;

        return true;
    }

    void SetPlayerAnimMovePam(string idleName = "IdleAndRun")
    {
        if (this._idleName != idleName) this._idleName = idleName;
        if (InputData.HasEvent(InputEvents.Moving))
        {
            
            horizontal = InputData.axisValue.normalized.x;
            vertical = InputData.axisValue.normalized.y;
            
            s1 = Mathf.Sqrt(horizontal * horizontal + vertical * vertical);

            if (s1 > 0.01f)
            {
                PlayerCtrlMovement(horizontal, vertical);
            }
        }
        anim.SetFloat(idleName, rigid.velocity.magnitude);
    }

    void PlayerCtrlMovement(float horizon,float vertical)
    {
        Vector3 dir = camera.transform.right * horizon + vertical * camera.transform.forward;
        dir.y = 0f;
        player.transform.forward = dir;

        var velocity = rigid.velocity;
        var move = dir * 3;

        velocity.x = move.x;
        velocity.z = move.z;

        rigid.velocity = velocity;
    }

}
