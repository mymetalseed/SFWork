using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Player管理中心
/// 离Monobehaviour
/// </summary>
[Serializable]
public class PlayerManager : Singleton<PlayerManager>
{
    #region 参数
    private string PlayerCenterPath = "Assets/AssetPackage/Prefabs/Camera/PlayerCenter.prefab";
    private GameObject PlayerCenter;
    public GameObject GetPlayerCenter => (PlayerCenter);
    private Camera MainCamera;
    public Camera GetCamera => (MainCamera);
    private RoleInfo playerInfo;
    private Player player;
    public Player GetPlayer => (player);

    [SerializeField]
    public PlayerController playerController;
    #endregion


    public async void InitPlayer()
    {
        playerInfo = singletonManager.GetPlayerInfo();
        //做角色的初始化
        ModelConfig mo = singletonManager.GetModelConfigById(playerInfo.ModelId);
        player = (await singletonManager.InstantiateAsync(mo.Path,PlayerCenter.transform)).GetComponent<Player>();
        player.gameObject.name = "Solvarg";
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.identity;
        player.transform.localScale = Vector3.one;
        player.gameObject.SetActive(false);
        player.InitRole(playerInfo);

        playerController = new PlayerController(this);
        playerController.OnInit();
    }

    #region 功能函数
    public void StartMove()
    {
        playerController.StartControl();
        singletonManager.Enable3rdCamera();
    }
    public void StopMove(Transform cameraPos= null)
    {
        playerController.StopConrtol();
        singletonManager.Close3rdCamera(cameraPos);
    }

    #endregion

    #region Unity CallBack
    public async override void Awake()
    {
        base.Awake();
        PlayerCenter = await singletonManager.InstantiateAsync(PlayerCenterPath, singletonManager.transform);
        PlayerCenter.name = "PlayerCenter";
        PlayerCenter.transform.localPosition = Vector3.zero;
        PlayerCenter.transform.localRotation = Quaternion.identity;
        PlayerCenter.transform.localScale = Vector3.one;
        MainCamera = PlayerCenter.transform.Find("Main Camera").GetComponent<Camera>();

        //初始化摄像机
        CameraManager.Instance.InitCameraManager();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
        playerController?.LateUpdate();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnGUI()
    {
        base.OnGUI();
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
        playerController?.Update();
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }
    #endregion
}
