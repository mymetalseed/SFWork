using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityChan.ImageEffects;
using System;

/// <summary>
/// 在Player之后
/// </summary>
public class CameraManager : Singleton<CameraManager>
{
    #region 参数
    Camera MainCamera;
    CinemachineBrain brain;

    Vector3 menuCameraPos;
    #endregion

    #region 功能
    /// <summary>
    /// 将摄像机位置重置到菜单面板
    /// </summary>
    public void ResetCameraToMenuView()
    {
        brain.enabled = false;
        MainCamera.transform.position = menuCameraPos;
    }

    public void EnableVirtualCamera()
    {
        brain.enabled = true;
    }

    public void CloseVirtualCamera(Transform resetCameraPos=null)
    {
        brain.enabled = false;
        if (resetCameraPos != null)
        {
            MainCamera.transform.position = resetCameraPos.position;
            MainCamera.transform.rotation = resetCameraPos.rotation;
        }
    }

    public void Enable3rdCamera()
    {
        if (SceneGlobalControl.Instance != null)
        {
            EnableVirtualCamera();
            SceneGlobalControl.Instance.cameraPart.playerCamera.Follow = singletonManager.PlayerInst.transform;
            SceneGlobalControl.Instance.cameraPart.playerCamera.LookAt = singletonManager.PlayerInst.transform;
            SceneGlobalControl.Instance.cameraPart.playerCamera.Priority = 1;
        }
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void InitCameraManager()
    {
        MainCamera = singletonManager.MainCamera;
        brain = MainCamera.gameObject.AddComponent<CinemachineBrain>();
        brain.enabled = false;
    }
    #endregion

    #region 相机特效控制
    /// <summary>
    /// 预准备转场
    /// </summary>
    /// <param name="effectType"></param>
    public void PrepareCameraEffect(ImageEffectType effectType)
    {
        switch (effectType)
        {
            case ImageEffectType.MaskFade:
                Solvarg_InkFade si =MainCamera.GetComponent<Solvarg_InkFade>();
                si.fadeRate = 0;
                si.enabled = true;
                break;
        }
    }

    /// <summary>
    /// 开始转场特效
    /// </summary>
    /// <param name="effectType">转场类型</param>
    /// <param name="duration">从开始到结束花费时间</param>
    /// <param name="onComplete">结束触发事件</param>
    public void StartCameraEffect(ImageEffectType effectType,float duration,Action onComplete=null)
    {
        PostEffectsBase effect=null;
        switch (effectType)
        {
            case ImageEffectType.MaskFade:
                Solvarg_InkFade si = MainCamera.GetComponent<Solvarg_InkFade>();
                effect = si;

                break;
        }
        StartCameraEffect(effect, duration, onComplete);
    }

    /// <summary>
    /// 开始停止转场,即开始转场
    /// </summary>
    /// <param name="effect"></param>
    /// <param name="duration"></param>
    /// <param name="onComplete"></param>
    public void StartCameraEffect(PostEffectsBase effect, float duration, Action onComplete=null)
    {
        if (effect == null)
        {
            onComplete?.Invoke();
            return;
        }
        singletonManager.Timer_Register(duration, 
            ()=> { 
                effect.enabled = false;
                onComplete?.Invoke(); 
            },
            (progress,deltaTime) =>
            {
                effect.fadeRate = progress;
            });
    }

    #endregion

    #region Unity Callback
    public override void Awake()
    {
        base.Awake();

        menuCameraPos = new Vector3(0, 1f, -10f);
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
