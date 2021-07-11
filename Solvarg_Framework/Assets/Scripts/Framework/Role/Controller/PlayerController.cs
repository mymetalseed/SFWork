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
    //Rigidbody rig;
    CharacterController characterController;
    Camera camera;

    private bool isActive;

    public float horizontal;
    public float vertical;
    public float moveRate;
    float s1;

    public float speedMulti=3.0f;

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
        //rig = player.GetComponent<Rigidbody>();
        characterController = player.GetComponent<CharacterController>();
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

    public void Update()
    {
        if (!CanMove()) return;
        SetPlayerAnimMovePam();

        //#普通攻击
        if (InputData.HasEvent(InputEvents.Attack))
        {
            (player[ControllerType.Action] as ActionController)
                .CastSkill(SkillType.eAttack);
        }
    }

    bool CanMove()
    {
        if (!isActive) return false;

        return true;
    }

    void SetPlayerAnimMovePam()
    {

        if (InputData.HasEvent(InputEvents.Moving))
        {
            horizontal = InputData.axisValue.normalized.x;
            vertical = InputData.axisValue.normalized.y;
            s1 = Mathf.Sqrt(horizontal * horizontal + vertical * vertical); ;

            moveRate = s1;

            anim.SetFloat("IdleAndRun", 1);

            if (moveRate > 0.01f)
            {
                PlayerCtrlMovement(horizontal, vertical);
            }
        }
        anim.SetFloat("IdleAndRun", rigid.velocity.magnitude);

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
