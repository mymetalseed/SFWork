using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SingletonManager
{

    public void SetApllicationConfig(Config co)
    {
        databaseManager.SetApllicationConfig(co);
    }
    /// <summary>
    /// 获取应用配置
    /// </summary>
    /// <param name="co"></param>
    public Config GetApllicationConfig()
    {
        return databaseManager.Config;
    }

    public void SetUIConfig(UIConfig co)
    {
        databaseManager.SetUIConfig(co);
    }
    /// <summary>
    /// 获取UI配置
    /// </summary>
    /// <param name="co"></param>
    public UIConfig GetUIConfig()
    {
        return databaseManager.UIConfig;
    }

    public void SetSceneConfig(SceneConfig co)
    {
        databaseManager.SetSceneConfig(co);
    }
    /// <summary>
    /// 获取场景配置
    /// </summary>
    /// <returns></returns>
    public SceneConfig GetSceneConfig()
    {
        return databaseManager.SceneCofnig;
    }
}
