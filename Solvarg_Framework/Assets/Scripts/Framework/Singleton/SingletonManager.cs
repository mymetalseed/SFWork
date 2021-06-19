using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class SingletonManager : MonoSingleton<SingletonManager>
{
    private GameObject _rootObj;
    private List<IMonoBehaviour> singltonList;

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

    #region 单例集
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
    PlayerManager playerManager;
    SettingManager settingManager;
    #endregion
    /// <summary>
    /// 在这里进行所有单例的初始化
    /// </summary>
    /// <returns></returns>
    public void InitSingletons()
    {
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
    #endregion
}
