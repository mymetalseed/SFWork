using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using static Defines;

public partial class SingletonManager
{
    public async Task EnterScene(EnumSceneName scName)
    {
        await sceneManager.EnterScene(scName);
    }

    public void LeaveScene()
    {
        sceneManager.LeaveScene();
    }

    public async Task LoadAsset()
    {
        await sceneManager.LoadAsset();
    }

    public void UnloadAsset()
    {
        sceneManager.UnLoadAsset();
    }

    /// <summary>
    /// 通过场景资源的路径进入场景
    /// </summary>
    /// <returns></returns>
    public async Task EnterSceneByPath(string scPath)
    {
        await Addressables.LoadSceneAsync(scPath).Task;
    }
}
