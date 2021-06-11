using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MenuScene : IScene
{
    public async Task EnterScene()
    {
        ModelConfig modelConfig = SingletonManager.Instance.GetModelConfig("WolfWithMoon");
        GameObject scRoot =  await SingletonManager.Instance.InstantiateAsync(modelConfig.Path);
        scRoot.name = modelConfig.Name;
    }

    public void LeaveScene()
    {
    }

    public async Task LoadAsset()
    {

    }

    public void UnloadAsset()
    {
    }
}
