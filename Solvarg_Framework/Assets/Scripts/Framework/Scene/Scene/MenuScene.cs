using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MenuScene : IScene
{
    private GameObject scRoot;

    private bool ProgressDone = false;

    #region 实现雾的动效
    private bool startFlow = false;
    private float speedRate=0.1f;
    private float maxBoundary=4.5f;
    private float firstX;
    private List<Transform> smokeTrans;
    #endregion

    public async Task EnterScene()
    {
        ProgressDone = false;
        startFlow = false;

        SingletonManager.Instance.Message_Subscribe(MessageRouter.ProgressClose,OnProgressDone);

        SingletonManager.Instance.ProgressUIInstance.SetProgressToolTip("正在进入菜单...");
        await Addressables.LoadSceneAsync(SingletonManager.Instance.GetSceneConfig()[0].Path).Task;
        SingletonManager.Instance.ProgressUIInstance.NotifyAssetProgress(1,2);
        await InitSmoke();
    }

    public void LeaveScene()
    {
        startFlow = false;
    }


    public async Task LoadAsset()
    {

    }

    public void UnloadAsset()
    {
        SingletonManager.Instance.CloseUI(Defines.EnumUIName.Menu);
    }

    private void OnProgressDone(Message message)
    {
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.ProgressClose, OnProgressDone);

        SingletonManager.Instance.ProgressUIInstance.SetProgressToolTip("加载完了,请按Space跳过XD");

        ProgressDone = true;
    }

    public async void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {

        if (scRoot != null && ProgressDone && startFlow)
        {
            for(int i=0;i< smokeTrans.Count; ++i)
            {
                if (smokeTrans[i] == null) return;
                smokeTrans[i].localPosition = smokeTrans[i].localPosition - new Vector3(speedRate * Time.deltaTime,0,0);
                if(Mathf.Abs(smokeTrans[i].localPosition.x-firstX)>= maxBoundary* smokeTrans.Count)
                {
                    smokeTrans[i].localPosition = smokeTrans[i].localPosition + new Vector3(firstX- smokeTrans[i].localPosition.x, 0,0);
                }
            }
        }
    }

    private async Task InitSmoke()
    {
        SingletonManager.Instance.ProgressUIInstance.SetProgressToolTip("Solvarg正在嚎叫...");
        ModelConfig modelConfig = SingletonManager.Instance.GetModelConfig("WolfWithMoon");
        scRoot = await SingletonManager.Instance.InstantiateAsync(modelConfig.Path);
        scRoot.name = modelConfig.Name;
        Transform smoke = scRoot.transform.Find("Smoke");
        smokeTrans = new List<Transform>(smoke.GetComponentsInChildren<Transform>());
        smokeTrans.RemoveAt(0);
        firstX = smokeTrans[0].localPosition.x;
        Debug.LogError(smokeTrans.Count + " " + firstX);

        startFlow = true;
        SingletonManager.Instance.ProgressUIInstance.NotifyAssetProgress(2, 2);
    }

    public async Task OnProgressDone()
    {
        await SingletonManager.Instance.OpenUI(Defines.EnumUIName.Menu);
    }
}
