using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using static Defines;

public partial class SingletonManager
{
    public async Task Scene_EnterScene(EnumSceneName scName)
    {
        await sceneManager.EnterScene(scName);
    }

    public void Scene_LeaveScene()
    {
        sceneManager.LeaveScene();
    }

    public async Task Scene_LoadAsset()
    {
        await sceneManager.LoadAsset();
    }

    public void Scene_UnloadAsset()
    {
        sceneManager.UnLoadAsset();
    }

    /// <summary>
    /// 通过场景资源的路径进入场景
    /// </summary>
    /// <returns></returns>
    public async Task Scene_EnterSceneByPath(string scPath)
    {
        await Addressables.LoadSceneAsync(scPath).Task;
    }

}
