using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景基类
/// </summary>
public interface IScene
{
    void EnterScene();
    void LeaveScene();
    void UnloadAsset();
    void LoadAsset();
}
