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
    public float speed;
    float s1;

    public float speedMulti=3.0f;
    #endregion

    public PlayerController(PlayerManager pm)
    {
        this.playerManager = pm;
        isActive = false;
    }

    public void OnInit()
    {
        player = playerManager.GetPlayer;
        anim = player.GetComponent<Animator>();
        //rig = player.GetComponent<Rigidbody>();
        characterController = player.GetComponent<CharacterController>();
        camera = playerManager.GetCamera;

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
    }

    bool CanMove()
    {
        if (!isActive) return false;

        return true;
    }

    void SetPlayerAnimMovePam()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        s1 = Mathf.Sqrt(horizontal * horizontal + vertical * vertical); ;

        speed = s1;

        anim.SetFloat("IdleAndRun",speed);

        if (speed > 0.01f)
        {
            PlayerCtrlMovement(horizontal, vertical);
        }
    }

    void PlayerCtrlMovement(float horizon,float vertical)
    {
        Vector3 dir = camera.transform.right * horizon + vertical * camera.transform.forward;

        dir.y = 0f;
        player.transform.forward = dir;

        characterController.SimpleMove(speed * dir * speedMulti);
    }

}
