using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Defines;

#region 全局委托

public delegate void StateChangeEvent(Object ui,Defines.EnumObjectState newState,Defines.EnumObjectState oldState);

#endregion

#region
public static class UIPathDefines
{
    /// <summary>
    /// UI预设
    /// </summary>
    public static string UI_PREFAB = "UIPrefab/";
    /// <summary>
    /// UI小控件预设
    /// </summary>
    public static string UI_CONTROLS_PREFAB = "UIPrefab/Control/";
    /// <summary>
    /// UI子页面预设
    /// </summary>
    public static string UI_SUBUI_PREFAB = "UIPrefab/SubUI/";
    /// <summary>
    /// ICON路径
    /// </summary>
    public static string UI_ICON_PATH = "UI/Icon/";
    /// <summary>
    /// DIALOG路径
    /// </summary>
    public static string UI_DIALOG_PREFAB = "Assets/AssetPackage/UI/Dialog/Dialog.prefab";
    public static string UI_MAIN = "Assets/AssetPackage/UI/UIMain.prefab";
    public static string EVENTSYSTEM = "Assets/AssetPackage/UI/EventSystem.prefab";

    public static string GetUIPrefabsPathByType(EnumUIType _uiType)
    {
        string _path = string.Empty;
        switch (_uiType)
        {
            case EnumUIType.TestOne:
                _path = UI_PREFAB + "TestOne";
                break;
            default:
                Debuger.Log("Not Find EnumUIType: " + _uiType.ToString());
                break;
        }
        return _path;
    }

    public static System.Type GetUIScriptByType(EnumUIType _uiType)
    {
        System.Type _scriptType = null;
        switch (_uiType)
        {
            case EnumUIType.TestOne:
                _scriptType = typeof(TestOne);
                break;
            default:
                Debuger.Log("Not Find EnumUIType: " + _uiType.ToString());
                break;
        }
        return _scriptType;
    }
}

#endregion


public class Defines
{
    #region Global全剧枚举
    public enum EnumObjectState { 
        None,
        Initial,
        Loading,
        Ready,
        Paused,
        Resume,
        Disabled,
        Closing
    }
    #endregion
    public Defines()
    {

    }

    #region UIDefine
    public enum EnumUIType
    {
        None,
        TestOne,
        Dialog
    }
    #endregion
}
