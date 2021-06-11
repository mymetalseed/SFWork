using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Defines;

public class SceneManager : Singleton<SceneManager>
{
    private IScene currentScene;
    public async Task EnterScene(Defines.EnumSceneName sceneName)
    {
        if (sceneName == EnumSceneName.Menu)
        {
            currentScene = new MenuScene();
        }
        else
        {
            currentScene = null;
            Debuger.LogError("错误的场景");
        }

        await EnterScene();
        await LoadAsset();
    }

    private async Task EnterScene()
    {
        if (currentScene == null) return;
        await currentScene.EnterScene();
    }

    public void LeaveScene()
    {
        if (currentScene == null) return;
        currentScene.LeaveScene();
        UnLoadAsset();
    }

    public async Task LoadAsset()
    {
        if (currentScene == null) return;
        await currentScene.LoadAsset();
    }

    public void UnLoadAsset()
    {
        if (currentScene == null) return;
        currentScene.UnloadAsset();
    }

}
