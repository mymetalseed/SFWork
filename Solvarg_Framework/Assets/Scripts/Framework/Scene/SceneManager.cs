using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Defines;

public class SceneManager : Singleton<SceneManager>
{
    private IScene currentScene;
    public void EnterScene(Defines.EnumSceneName sceneName)
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

        EnterScene();
    }

    private void EnterScene()
    {
        if (currentScene == null) return;
        currentScene.EnterScene();
    }

    public void LeaveScene()
    {
        if (currentScene == null) return;
        currentScene.LeaveScene();
    }

    public void LoadAsset()
    {
        if (currentScene == null) return;
        currentScene.LoadAsset();
    }

    public void UnLoadAsset()
    {
        if (currentScene == null) return;
        currentScene.UnloadAsset();
    }

}
