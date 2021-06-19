using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player管理中心
/// 离Monobehaviour
/// </summary>
public class PlayerManager : Singleton<PlayerManager>
{
    private string PlayerCenterPath = "Assets/AssetPackage/Prefabs/Camera/PlayerCenter.prefab";
    private GameObject PlayerCenter;
    private Camera MainCamera;
    private RoleInfo playerInfo;
    private Player player;

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
    }

    #region 功能函数


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
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
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
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }
    #endregion
}
