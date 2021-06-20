using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TutorialScene : IScene
{
    UIProgress uiProgress = SingletonManager.Instance.ProgressUIInstance; 
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
        //先加载场景
        uiProgress.SetProgressToolTip("正在构建教程森林~");
        int count = sceneGlobalControl.modelPart.Count + sceneGlobalControl.rolePart.Count+1;
        int currentCnt = 1;

        List<ModelPart> mp = sceneGlobalControl.modelPart;
        foreach(ModelPart m in mp)
        {
            string mid = m.modelId;
            Transform trans = m.modelPos;

            ModelConfig mc = SingletonManager.Instance.GetModelConfigById(mid);
            uiProgress.SetProgressToolTip("正在构建场景的" + mc.Name);

            GameObject model = await SingletonManager.Instance.InstantiateAsync(mc.Path);
            model.name = mc.Name;

            model.transform.position = trans.position;
            model.transform.rotation = trans.rotation;
            model.transform.localScale = trans.localScale;
            uiProgress.NotifyProgress(currentCnt++,count);
        }

        uiProgress.SetProgressToolTip("正在将角色传送到目标区域~");
        //根据SceneGlobalControl加载资源
        //加载Role
        //不同的场景根据对应的需要组织角色
        foreach (RolePart pr in sceneGlobalControl.rolePart)
        {
            if (pr.roleSide == PlayerSide.Player)
            {
                SingletonManager.Instance.PlayerInst.transform.position = pr.rolePos.position;
                SingletonManager.Instance.PlayerInst.transform.rotation = pr.rolePos.rotation;
                SingletonManager.Instance.PlayerInst.transform.localScale = pr.rolePos.localScale;
                SingletonManager.Instance.PlayerInst.gameObject.SetActive(true);
            }
            uiProgress.NotifyProgress(currentCnt++, count);
        }

        uiProgress.SetProgressToolTip("正在催促摄影师~");
        //初始化Camera位置(后面需要加其他的)
        CameraPart cp = sceneGlobalControl.cameraPart;
        SingletonManager.Instance.MainCamera.transform.position = cp.cameraPos.position;
        SingletonManager.Instance.MainCamera.transform.rotation = cp.cameraPos.rotation;
        SingletonManager.Instance.MainCamera.transform.localScale = cp.cameraPos.localScale;
        uiProgress.NotifyProgress(currentCnt++, count);
    }

    public async Task OnProgressDone()
    {
        
    }

    public void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        
    }

    public void UnloadAsset()
    {
        SingletonManager.Instance.PlayerInst.gameObject.SetActive(false);
    }

}
