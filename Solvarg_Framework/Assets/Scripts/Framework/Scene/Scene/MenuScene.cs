using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MenuScene : IScene
{
    public async Task EnterScene()
    {
        SingletonManager.Instance.Message_Subscribe(MessageRouter.ProgressClose,OnProgressDone);

        SingletonManager.Instance.ProgressUIInstance.SetProgressToolTip("正在进入菜单...");
        await Addressables.LoadSceneAsync(SingletonManager.Instance.GetSceneConfig()[0].Path).Task;
        SingletonManager.Instance.ProgressUIInstance.NotifyAssetProgress(1,2);
        SingletonManager.Instance.ProgressUIInstance.SetProgressToolTip("Solvarg正在嚎叫...");
        ModelConfig modelConfig = SingletonManager.Instance.GetModelConfig("WolfWithMoon");
        GameObject scRoot =  await SingletonManager.Instance.InstantiateAsync(modelConfig.Path);
        Debuger.Log("加载完毕");
        SingletonManager.Instance.ProgressUIInstance.NotifyAssetProgress(2, 2);

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

    private async void OnProgressDone(Message message)
    {
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.ProgressClose, OnProgressDone);
        await SingletonManager.Instance.OpenUI(Defines.EnumUIName.Menu);
    }

}
