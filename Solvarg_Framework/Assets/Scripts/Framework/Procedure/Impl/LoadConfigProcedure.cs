using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProcedureOwner = IFsm<ProcedureManager>;
using Newtonsoft;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class LoadConfigProcedure : ProcedureBase
{
    private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();

    
    public override void OnEnter(ProcedureOwner fsm)
    {
        base.OnEnter(fsm);
        Debuger.LogError("进入配置流程");
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadApplicationConfigSuccess, OnLoadConfigSuccess);
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadApplicationConfigFailure, OnLoadConfigFailure);
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadUIConfigSuccess, OnLoadUIConfigSuccess);
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadUIConfigFailure, OnLoadConfigFailure);
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadSceneConfigSuccess, OnLoadSceneConfigSuccess);
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadSceneConfigFailure, OnLoadConfigFailure);
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadModelConfigSuccess, OnModelConfigSuccess);
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadModelConfigFailure, OnLoadConfigFailure);



        PreloadResources();
    }
    public override void OnInit(ProcedureOwner fsm)
    {
        base.OnInit(fsm);
        Debuger.LogError("初始化配置流程");
        m_LoadedFlag.Add("Config",false);
        m_LoadedFlag.Add("UIConfig",false);
        m_LoadedFlag.Add("SceneConfig",false);
        m_LoadedFlag.Add("ModelConfig",false);
    }

    public override void OnLeave(ProcedureOwner fsm, bool isShutDown)
    {
        base.OnLeave(fsm, isShutDown);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadApplicationConfigSuccess, OnLoadConfigSuccess);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadApplicationConfigFailure, OnLoadConfigFailure);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadUIConfigSuccess, OnLoadUIConfigSuccess);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadUIConfigFailure, OnLoadConfigFailure);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadSceneConfigSuccess, OnLoadSceneConfigSuccess);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadSceneConfigFailure, OnLoadConfigFailure);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadModelConfigSuccess, OnModelConfigSuccess);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadModelConfigFailure, OnLoadConfigFailure);


        Debuger.LogError("离开配置流程");
    }

    public override void OnUpdate(ProcedureOwner fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

        foreach (var k in m_LoadedFlag)
        {
            if (k.Value == false)
            {
                return;
            }
        }
        ChangeState<PreloadProcedure>(fsm);
    }

    private async void PreloadResources()
    {
        await LoadApplicationConfig();
        await LoadUIConfig();
        await LoadSceneConfig();
        await LoadModelConfig();
    }

    #region 加载ApplicationCfonig
    private async Task LoadApplicationConfig() {
        //加载配置
        Debuger.Log("加载配置文件");
        List<Config> co = await JsonHelper.DeserializeFromPath<List<Config>>
            ("Assets/AssetPackage/database/json_database/ApplicationConfig.json");
        if (co != null)
        {
            Message message = new Message(MessageRouter.LoadApplicationConfigSuccess, this);
            message.Add("msg", "Config加载完毕");
            message.Add("data", co);
            SingletonManager.Instance.Message_FireAsync(message);
        }
        else
        {
            Message message = new Message(MessageRouter.LoadApplicationConfigFailure, this);
            message.Add("msg", "Config加载失败");
            SingletonManager.Instance.Message_FireAsync(message);
        }
    }

    private void OnLoadConfigSuccess(Message message)
    {
        //配置文件加载完毕
        Debuger.Log("配置文件加载完毕" + message["msg"]);
        List<Config> co = message["data"] as List<Config>;
        SingletonManager.Instance.SetApllicationConfig(co);
        Debuger.Log("游戏语言版本： " + co[0].Language);
        m_LoadedFlag["Config"] = true;
    }


    #endregion

    #region 加载UIConfig
    private async Task LoadUIConfig()
    {
        //加载配置
        Debuger.Log("加载UI配置文件");
        List<UIConfig> co = await JsonHelper.DeserializeFromPath<List<UIConfig>>
            ("Assets/AssetPackage/database/json_database/UIConfig.json");
        if (co != null)
        {
            Message message = new Message(MessageRouter.LoadUIConfigSuccess, this);
            message.Add("msg", "UIConfig加载完毕");
            message.Add("data", co);
            SingletonManager.Instance.Message_FireAsync(message);
        }
        else
        {
            Message message = new Message(MessageRouter.LoadUIConfigFailure, this);
            message.Add("msg", "UIConfig加载失败");
            SingletonManager.Instance.Message_FireAsync(message);
        }

    }

    private void OnLoadUIConfigSuccess(Message message)
    {
        //配置文件加载完毕
        Debuger.Log("配置文件加载完毕" + message["msg"]);
        List<UIConfig> co = message["data"] as List<UIConfig>;
        SingletonManager.Instance.SetUIConfig(co);
        m_LoadedFlag["UIConfig"] = true;
    }
    #endregion

    #region 加载SceneConfig
    private async Task LoadSceneConfig()
    {
        //加载配置
        Debuger.Log("加载Scene配置文件");
        List<SceneConfig> co = await JsonHelper.DeserializeFromPath<List<SceneConfig>>
            ("Assets/AssetPackage/database/json_database/SceneConfig.json");
        if (co != null)
        {
            Message message = new Message(MessageRouter.LoadSceneConfigSuccess, this);
            message.Add("msg", "SceneConfig加载完毕");
            message.Add("data", co);
            SingletonManager.Instance.Message_FireAsync(message);
        }
        else
        {
            Message message = new Message(MessageRouter.LoadSceneConfigFailure, this);
            message.Add("msg", "SceneConfig加载失败");
            SingletonManager.Instance.Message_FireAsync(message);
        }
    }

    private void OnLoadSceneConfigSuccess(Message message)
    {
        //配置文件加载完毕
        Debuger.Log("配置文件加载完毕" + message["msg"]);
        List<SceneConfig> co = message["data"] as List<SceneConfig>;
        SingletonManager.Instance.SetSceneConfig(co);
        m_LoadedFlag["SceneConfig"] = true;
    }
    #endregion

    #region 加载ModelConfig
    private async Task LoadModelConfig()
    {
        //加载配置
        Debuger.Log("加载Model配置文件");
        List<ModelConfig> co = await JsonHelper.DeserializeFromPath<List<ModelConfig>>
            ("Assets/AssetPackage/database/json_database/ModelConfig.json");
        if (co != null)
        {
            Message message = new Message(MessageRouter.LoadModelConfigSuccess, this);
            message.Add("msg", "ModelConfig加载完毕");
            message.Add("data", co);
            SingletonManager.Instance.Message_FireAsync(message);
        }
        else
        {
            Message message = new Message(MessageRouter.LoadModelConfigFailure, this);
            message.Add("msg", "ModelConfig加载失败");
            SingletonManager.Instance.Message_FireAsync(message);
        }
    }

    private void OnModelConfigSuccess(Message message)
    {
        //配置文件加载完毕
        Debuger.Log("资源配置文件加载完毕" + message["msg"]);
        List<ModelConfig> co = message["data"] as List<ModelConfig>;
        SingletonManager.Instance.SetModelConfig(co);
        m_LoadedFlag["ModelConfig"] = true;
    }
    #endregion


    private void OnLoadConfigFailure(Message message)
    {
        //配置文件加载完毕
        Debuger.Log("配置文件加载失败" + message["msg"]);
    }
}
