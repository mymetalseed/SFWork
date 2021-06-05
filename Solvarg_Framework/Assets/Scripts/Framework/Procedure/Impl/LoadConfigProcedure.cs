﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProcedureOwner = IFsm<ProcedureManager>;
using Newtonsoft;
using Newtonsoft.Json;

public class LoadConfigProcedure : ProcedureBase
{
    private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();

    
    public override void OnEnter(ProcedureOwner fsm)
    {
        base.OnEnter(fsm);
        Debuger.LogError("进入配置流程");
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadApplicationConfigSuccess, OnLoadConfigSuccess);
        SingletonManager.Instance.Message_Subscribe(MessageRouter.LoadApplicationConfigFailure, OnLoadConfigFailure);

        PreloadResources();
    }
    public override void OnInit(ProcedureOwner fsm)
    {
        base.OnInit(fsm);
        Debuger.LogError("初始化配置流程");
        m_LoadedFlag.Add("Config",false);
    }

    public override void OnLeave(ProcedureOwner fsm, bool isShutDown)
    {
        base.OnLeave(fsm, isShutDown);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadApplicationConfigSuccess, OnLoadConfigSuccess);
        SingletonManager.Instance.Message_UnSubscribe(MessageRouter.LoadApplicationConfigFailure, OnLoadConfigFailure);
        
        
        Debuger.LogError("离开配置流程");
    }

    public override void OnUpdate(ProcedureOwner fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        if (Input.GetKeyDown(KeyCode.N))
        {
            ChangeState<PreloadProcedure>(fsm);
        }
        foreach (var k in m_LoadedFlag.Values)
        {
            if (k == false) return;
        }
        ChangeState<PreloadProcedure>(fsm);
    }

    private async void PreloadResources()
    {
        LoadConfig();
    }

    private async void LoadConfig() {
        //加载配置
        Debuger.Log("加载配置文件");
        List<Config> co = await JsonHelper.DeserializeFromPath<List<Config>>
            ("Assets/AssetPackage/database/json_database/ApplicationConfig.json");
        if (co != null)
        {
            Message message = new Message(MessageRouter.LoadApplicationConfigSuccess, this);
            message.Add("msg", "Config加载完毕");
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
        m_LoadedFlag["Config"] = true;

    }
    private void OnLoadConfigFailure(Message message)
    {
        //配置文件加载完毕
        Debuger.Log("配置文件加载失败");

    }
}