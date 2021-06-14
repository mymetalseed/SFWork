using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 场景基类
/// </summary>
public interface IScene
{
    Task EnterScene();
    void LeaveScene();
    void UnloadAsset();
    Task LoadAsset();

    void OnUpdate(float elapseSeconds, float realElapseSeconds);
}
