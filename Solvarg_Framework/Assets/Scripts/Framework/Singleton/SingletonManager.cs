﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class SingletonManager : MonoSingleton<SingletonManager>
{
    private GameObject _rootObj;
    private List<IMonoBehaviour> singltonList;
    private List<IApplication> singltonList_Application;

    private static List<Action> _singletonReleaseList = new List<Action>();

    private bool isDone = false;
    public bool IsDone => (isDone);

    public void Awake()
    {
        isDone = false;
#if UNITY_EDITOR
        Debuger.debugerEnable = true;
#endif
        Debuger.debugerEnable = true;
        singltonList = new List<IMonoBehaviour>();
        singltonList_Application = new List<IApplication>();
        _rootObj = gameObject;
        GameObject.DontDestroyOnLoad(_rootObj);

    }

    /// <summary>
    /// 在这里进行所有单例的销毁
    /// </summary>
    public void OnApplicationQuit()
    {
        for (int i = _singletonReleaseList.Count - 1; i >= 0; i--)
        {
            _singletonReleaseList[i]();
        }
    }

    public void SetToSingletonList(IMonoBehaviour manager)
    {
        singltonList.Add(manager);
    }

    public void SetToApplicationControlList(IApplication manager)
    {
        singltonList_Application.Add(manager);
    }

    #region 单例集
    LuaManager luaManager;
    MessageDispatcher messageDispatcher;
    TimerManager timerManager;
    ResManager resManager;
    UIManager uiManager;
    AssetManager assetManager;
    FsmManager fsmManager;
    ProcedureManager procedureManager;
    DatabaseManager databaseManager;
    SceneManager sceneManager;
    QuestManager questManager;
    RoleManager roleManager;
    [SerializeField]
    PlayerManager playerManager;
    SettingManager settingManager;
    CameraManager cameraManager;
    DialoguesManager dialoguesManager;
    AnimatorManager animatorManager;
    IconManager iconManager;
    ItemManager itemManager;
    WeaponManager weaponManager;
    MouseManager mouseManager;
    InputManager inputManager;
    ActionManager actionManager;
    MusicManager musicManager;
    SkillManager skillManager;
    #endregion
    /// <summary>
    /// 在这里进行所有单例的初始化
    /// </summary>
    /// <returns></returns>
    public void InitSingletons()
    {
        luaManager = LuaManager.Instance.InitSingleton(this);
        messageDispatcher = MessageDispatcher.Instance.InitSingleton(this);
        timerManager = TimerManager.Instance.InitSingleton(this);
        resManager = ResManager.Instance.InitSingleton(this);
        uiManager = UIManager.Instance.InitSingleton(this);
        assetManager = AssetManager.Instance.InitSingleton(this);
        fsmManager = FsmManager.Instance.InitSingleton(this);
        procedureManager = ProcedureManager.Instance.InitSingleton(this);
        databaseManager = DatabaseManager.Instance.InitSingleton(this);
        sceneManager = SceneManager.Instance.InitSingleton(this);
        questManager = QuestManager.Instance.InitSingleton(this);
        roleManager = RoleManager.Instance.InitSingleton(this);
        playerManager = PlayerManager.Instance.InitSingleton(this);
        settingManager = SettingManager.Instance.InitSingleton(this);
        cameraManager = CameraManager.Instance.InitSingleton(this);
        dialoguesManager = DialoguesManager.Instance.InitSingleton(this);
        animatorManager = AnimatorManager.Instance.InitSingleton(this);
        iconManager = IconManager.Instance.InitSingleton(this);
        itemManager = ItemManager.Instance.InitSingleton(this);
        weaponManager = WeaponManager.Instance.InitSingleton(this);
        mouseManager = MouseManager.Instance.InitSingleton(this);
        inputManager = InputManager.Instance.InitSingleton(this);
        actionManager = ActionManager.Instance.InitSingleton(this);
        musicManager = MusicManager.Instance.InitSingleton(this);
;       skillManager = SkillManager.Instance.InitSingleton(this);

        OnInit();
        _singletonReleaseList.Add(delegate ()
        {
            if (singltonList != null)
            {
                foreach (var subManager in singltonList)
                {
                    if (subManager != null)
                        subManager.OnRelease();
                }
            }
        });
        isDone = true;
    }

    #region Mono调用模块
    private void OnInit()
    {
        if (singltonList != null)
        {
            foreach (var subManager in singltonList)
            {
                if (subManager != null)
                    subManager.Awake();
            }
        }
    }

    private void Update()
    {
        if (singltonList != null)
        {
            foreach (var subManager in singltonList)
            {
                if (subManager != null)
                {
                    subManager.Update();
                    subManager.Update(Time.deltaTime, Time.unscaledDeltaTime);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (singltonList != null)
        {
            foreach (var subManager in singltonList)
            {
                if (subManager != null)
                    subManager.FixedUpdate();
            }
        }
    }

    private void LateUpdate()
    {
        if (singltonList != null)
        {
            foreach (var subManager in singltonList)
            {
                if (subManager != null)
                    subManager.LateUpdate();
            }
        }
    }

    public void OnGUI() {
        if (singltonList != null)
        {
            foreach (var subManager in singltonList)
            {
                if (subManager != null)
                    subManager.OnGUI();
            }
        }
    }
    public void OnDisable() {
        if (singltonList != null)
        {
            foreach (var subManager in singltonList)
            {
                if (subManager != null)
                    subManager.OnDisable();
            }
        }
    }
    public void OnDestroy() {
        if (singltonList != null)
        {
            foreach (var subManager in singltonList)
            {
                if (subManager != null)
                    subManager.OnDestroy();
            }
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (singltonList_Application != null)
        {
            foreach (var subManager in singltonList_Application)
            {
                if (subManager != null)
                    subManager.OnApplicationFocus(focus);
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (singltonList_Application != null)
        {
            foreach (var subManager in singltonList_Application)
            {
                if (subManager != null)
                    subManager.OnApplicationPause(pause);
            }
        }
    }

    
    #endregion
}
