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
    /// DIALOG路径
    /// </summary>
    public static string UI_MAIN = "Assets/AssetPackage/UI/UIMain.prefab";
    public static string EVENTSYSTEM = "Assets/AssetPackage/UI/EventSystem.prefab";


    public static System.Type GetUIScriptByType(EnumUIName _uiType)
    {
        System.Type _scriptType = null;
        switch (_uiType)
        {
            case EnumUIName.TestOne:
                _scriptType = typeof(TestOne);
                break;
            case EnumUIName.Dialog:
                _scriptType = typeof(UIDialog);
                break;
            case EnumUIName.Menu:
                _scriptType = typeof(UIMenu);
                break;
            case EnumUIName.Progress:
                _scriptType = typeof(UIProgress);
                break;
            case EnumUIName.Dialogue:
                _scriptType = typeof(UIDialogue);
                break;
            default:
                Debuger.Log("Not Find EnumUIName: " + _uiType.ToString());
                break;
        }
        return _scriptType;
    }
}

#endregion


public static class Defines
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

    #region UIDefine
    public enum EnumUIName
    {
        None,
        TestOne,
        Dialog,
        Menu,
        Progress,
        Dialogue
    }

    /// <summary>
    /// 这个是所有场景的名称
    /// </summary>
    public enum EnumSceneName
    {
        None,
        Menu,
        Tutorial
    }

    /// <summary>
    /// 这个是场景的类型
    /// </summary>
    public enum EnumSceneType
    {
        None,
        Menu,
        Tutorial
    }

    public enum EnumApplicationLocallization
    {
        CH,//中国
    }
    #endregion
}

#region RoleDefine
public enum EnumRoleState
{
    Idle,
    Pause,
    Hide,
    Die,
}

public enum PlayerSide
{
    Player,
    Npc,
    Dynamic,//动态物体(可交互物体)
    Enemy,
    Boss
}
#endregion

#region Animator And Skill Define
public enum AnimTrigState
{
    TrigBegin,
    TrigEnd
}

public enum SkillStateID
{
    eNULL = -1,
    eIdle = 0,
    eChase = 1,
    eAttack = 2,
    eGetHit = 3,
    eFlyAway = 4,//击飞
    eDie = 5,
    eTaunting = 6,//嘲笑
    eWalkBack = 7,//后退
    eVictory = 8,
}

public enum SkillType
{
    eAttack = 0,
    eSkill,
}
#endregion