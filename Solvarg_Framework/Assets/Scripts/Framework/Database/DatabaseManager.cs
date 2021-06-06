﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Defines;

public class DatabaseManager : Singleton<DatabaseManager>
{
    public override void Awake()
    {
        base.Awake();
    }
    #region 参数
    private List<Config> config;
    public List<Config> Config => (config);

    private List<UIConfig> uiConfig;
    public List<UIConfig> UIConfig => (uiConfig);
    private Dictionary<EnumUIName, UIConfig> uiDict;
    public Dictionary<EnumUIName, UIConfig> UIDict => (uiDict);

    private List<SceneConfig> sceneConfig;
    public List<SceneConfig> SceneCofnig => (sceneConfig);
    private Dictionary<EnumSceneName, SceneConfig> sceneDict;
    public Dictionary<EnumSceneName, SceneConfig> SceneDict => (sceneDict);

    #endregion
    #region Set
    public void SetApllicationConfig(List<Config> co)
    {
        this.config = co;
    }
    public void SetUIConfig(List<UIConfig> co)
    {
        uiDict = new Dictionary<EnumUIName, UIConfig>();
        this.uiConfig = co;
        foreach (UIConfig c in co)
        {
            if (Enum.IsDefined(typeof(EnumUIName), c.Name))
            {
                uiDict.Add((EnumUIName)Enum.Parse(typeof(EnumUIName),c.Name),c);
            }
        }
    }
    public void SetSceneConfig(List<SceneConfig> co)
    {
        sceneDict = new Dictionary<EnumSceneName, SceneConfig>();
        this.sceneConfig = co;
        foreach (SceneConfig c in co)
        {
            if (Enum.IsDefined(typeof(EnumSceneName), c.Name))
            {
                sceneDict.Add((EnumSceneName)Enum.Parse(typeof(EnumSceneName), c.Name), c);
            }
        }
    }
    #endregion
}
