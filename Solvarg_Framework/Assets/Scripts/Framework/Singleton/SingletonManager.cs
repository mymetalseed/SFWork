using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class SingletonManager : MonoSingleton<SingletonManager>
{
    private GameObject _rootObj;
    private List<IMonoBehaviour> singltonList;

    private static List<Action> _singletonReleaseList = new List<Action>();

    public void Awake()
    {
#if UNITY_EDITOR
        Debuger.debugerEnable = true;
#endif
        singltonList = new List<IMonoBehaviour>();
        _rootObj = gameObject;
        GameObject.DontDestroyOnLoad(_rootObj);

        InitSingletons();
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
    #endregion
    /// <summary>
    /// 在这里进行所有单例的初始化
    /// </summary>
    /// <returns></returns>
    private void InitSingletons()
    {
        messageDispatcher = MessageDispatcher.Instance.InitSingleton(this);
        timerManager = TimerManager.Instance.InitSingleton(this);
        resManager = ResManager.Instance.InitSingleton(this);
        uiManager = UIManager.Instance.InitSingleton(this);
        assetManager = AssetManager.Instance.InitSingleton(this);


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
                    subManager.Update();
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
