using System;
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


    private List<ModelConfig> modelConfig;
    public List<ModelConfig> ModelConfigs => (modelConfig);
    /// <summary>
    /// 名字与模型实体对应
    /// </summary>
    private Dictionary<string, ModelConfig> modelDict;
    public Dictionary<string, ModelConfig> ModelDict => (modelDict);
    /// <summary>
    /// ID与模型实体对应
    /// </summary>
    private Dictionary<string, ModelConfig> modelIDDict;
    public Dictionary<string, ModelConfig> ModelIDDict=>(modelIDDict);
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

    public void SetModelConfig(List<ModelConfig> co)
    {
        this.modelConfig = co;
        modelDict = new Dictionary<string, ModelConfig>();
        modelIDDict = new Dictionary<string, ModelConfig>();
        foreach (ModelConfig mo in ModelConfigs)
        {
            if (modelDict.ContainsKey(mo.Name))
            {
                Debuger.LogError("配置模型错误");
                return;
            }
            Debuger.Log(mo.Name.ToString() + "加载完毕");
            modelDict[mo.Name] = mo;

            modelIDDict[mo.ID] = mo;
        }
    }
    #endregion
}
