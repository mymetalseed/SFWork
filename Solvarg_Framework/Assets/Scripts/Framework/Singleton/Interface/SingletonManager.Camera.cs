using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class SingletonManager
{
    /// <summary>
    /// 开启第三人称摄像机
    /// </summary>
    public void Enable3rdCamera()
    {
        cameraManager.Enable3rdCamera();
    }

    /// <summary>
    /// 关闭第三人称摄像机
    /// 参数: 是否需要重置摄像机位置
    /// </summary>
    public void Close3rdCamera(Transform resetCameraPos =null)
    {
        cameraManager.CloseVirtualCamera(resetCameraPos);
    }

    /// <summary>
    /// 开始转场特效
    /// </summary>
    /// <param name="effectType">转场类型</param>
    /// <param name="duration">从开始到结束花费时间</param>
    /// <param name="onComplete">结束触发事件</param>
    public void StartCameraEffect(ImageEffectType effectType, float duration, Action onComplete = null)
    {
        cameraManager.StartCameraEffect(effectType,duration,onComplete);
    }

    /// <summary>
    /// 预准备转场
    /// </summary>
    /// <param name="effectType"></param>
    public void PrepareCameraEffect(ImageEffectType effectType)
    {
        cameraManager.PrepareCameraEffect(effectType);
    }
}
