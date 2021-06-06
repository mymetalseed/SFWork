using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : Singleton<DatabaseManager>
{
    public override void Awake()
    {
        base.Awake();
    }
    #region 参数
    private Config config;
    public Config Config => (config);

    private UIConfig uiConfig;
    public UIConfig UIConfig => (uiConfig);

    private SceneConfig sceneConfig;
    public SceneConfig SceneCofnig => (sceneConfig);

    #endregion
    #region Set
    public void SetApllicationConfig(Config co)
    {
        this.config = co;
    }
    public void SetUIConfig(UIConfig co)
    {
        this.uiConfig = co;
    }
    public void SetSceneConfig(SceneConfig co)
    {
        this.sceneConfig = co;
    }
    #endregion
}
