using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Defines;

public class SceneManager : Singleton<SceneManager>
{
    private bool ProgressDone = false;
    private IScene currentScene;

    #region Unity callback
    public override void Awake()
    {
        base.Awake();
        SingletonManager.Instance.Message_Subscribe(MessageRouter.ProgressClose, OnProgressDone);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.ProgressClose, OnProgressDone);
    }
    #endregion

    public async Task EnterScene(Defines.EnumSceneName sceneName)
    {
        LeaveScene();
        ProgressDone = false;

        SingletonManager.Instance.OpenProgressUI();

        SceneConfig sc = singletonManager.GetSceneConfig(sceneName);
        if (sc.Type == EnumSceneType.Menu.ToString())
        {
            currentScene = new MenuScene();
        }else if (sc.Type == EnumSceneType.Tutorial.ToString())
        {
            currentScene = new TutorialScene(sc);
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
        System.GC.Collect();
    }

    public async override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
        if (currentScene != null)
        {
            currentScene.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        if (ProgressDone && singletonManager.ProgressUIInstance.gameObject.activeInHierarchy && InputData.Confirm)
        {
            SingletonManager.Instance.ProgressUIInstance.CloseProgress();
            //加载关闭后处理
            //先执行转场特效
            //在这里开启转场特效,后面追加到各个场景, 而不是这里
            singletonManager.PrepareCameraEffect(ImageEffectType.MaskFade);
            singletonManager.StartCameraEffect(ImageEffectType.MaskFade, 2f, () =>
            {
                //后进行场景自切换处理
                currentScene.OnProgressDone();
            });
        }
    }

    private async void OnProgressDone(Message message)
    {
        SingletonManager.Instance.ProgressUIInstance.SetProgressToolTip("加载完了,请按Enter跳过XD");
        
        ProgressDone = true;
    }

}
