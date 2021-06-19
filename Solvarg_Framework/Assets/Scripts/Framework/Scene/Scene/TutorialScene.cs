using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TutorialScene : IScene
{
    SceneConfig sc;
    SceneGlobalControl sceneGlobalControl;
    public TutorialScene(SceneConfig sc)
    {
        this.sc = sc;
    }
    public async Task EnterScene()
    {
        Debuger.LogError("进入教程关卡");
        await SingletonManager.Instance.EnterSceneByPath(sc.Path);
        sceneGlobalControl = SceneGlobalControl.Instance;
    }

    public void LeaveScene()
    {
        throw new System.NotImplementedException();
    }

    public async Task LoadAsset()
    {
        //根据SceneGlobalControl加载资源
        throw new System.NotImplementedException();
    }

    public Task OnProgressDone()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        throw new System.NotImplementedException();
    }

    public void UnloadAsset()
    {
        throw new System.NotImplementedException();
    }

}
