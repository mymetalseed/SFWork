using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SingletonManager
{
    #region 应用配置
    public void SetApllicationConfig(List<Config> co)
    {
        databaseManager.SetApllicationConfig(co);
    }
    /// <summary>
    /// 获取应用配置
    /// </summary>
    /// <param name="co"></param>
    public List<Config> GetApllicationConfig()
    {
        return databaseManager.Config;
    }
    #endregion

    #region UI配置
    public void SetUIConfig(List<UIConfig> co)
    {
        databaseManager.SetUIConfig(co);
    }
    /// <summary>
    /// 获取UI配置
    /// </summary>
    /// <param name="co"></param>
    public List<UIConfig> GetUIConfig()
    {
        return databaseManager.UIConfig;
    }
    public UIConfig GetUIConfig(Defines.EnumUIName uiName)
    {
        UIConfig res;
        if (databaseManager.UIDict.TryGetValue(uiName, out res))
        {
            return res;
        }
        else
        {
            Debuger.LogError("不存在的UI类型: " + uiName);
            return null;
        }
    }
    #endregion

    #region 场景配置
    public void SetSceneConfig(List<SceneConfig> co)
    {
        databaseManager.SetSceneConfig(co);
    }
    public SceneConfig GetSceneConfig(Defines.EnumSceneName scName)
    {
        SceneConfig res;
        if (databaseManager.SceneDict.TryGetValue(scName, out res))
        {
            return res;
        }
        else
        {
            Debuger.LogError("不存在的场景类型: " + scName);
            return null;
        }
    }

    /// <summary>
    /// 获取场景配置
    /// </summary>
    /// <returns></returns>
    public List<SceneConfig> GetSceneConfig()
    {
        return databaseManager.SceneCofnig;
    }
    #endregion

}
