using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Defines;

public abstract class  BaseUI : MonoBehaviour
{
    #region 缓存
    private GameObject _cacheGameObject;
    public GameObject CacheGameObject
    {
        get {
            if (_cacheGameObject == null)
            {
                _cacheGameObject = this.gameObject;
            }
            return _cacheGameObject;
        }
    }

    private Transform _cacheTransform;
    public Transform CacheTransform
    {
        get
        {
            if (this._cacheTransform == null)
            {
                _cacheTransform = this.transform;
            }
            return _cacheTransform;
        }
    }
    #endregion

    #region EnumObjectState & UIType

    protected EnumObjectState _state = EnumObjectState.Initial;

    public event StateChangeEvent StateChanged;

    public EnumObjectState State
    {
        protected get
        {
            return this._state;
        }
        set
        {
            EnumObjectState oldState = this._state;
            this._state = value;
            //触发状态转换事件
            if (StateChanged != null)
                StateChanged(this, this._state, oldState);
        }
    }

    public abstract EnumUIType GetUIType();
    #endregion

    private void Start()
    {
        OnStart();
    }
    private void Awake()
    {
        OnAwake();
    }

    private void Update()
    {
        if (this._state == EnumObjectState.Paused || this._state==EnumObjectState.Closing) return;
        if (this._state == EnumObjectState.Ready) {
            OnUpdate(Time.deltaTime);
        }
    }

    public void Pause()
    {
        OnPause();
    }

    public void Resume() {
        OnResume();
    }

    public void Release()
    {
        this.State = EnumObjectState.Closing;
        GameObject.Destroy(this.CacheGameObject);
        OnRelease();
    }
    private void OnDestroy()
    {
        this.State = EnumObjectState.None;
    }
    protected virtual void OnStart() { }
    protected virtual void OnAwake() {
        this.State = EnumObjectState.Loading;
        //播放音乐
        this.OnPlayOpenUIAudio();
    }

    protected virtual void OnPause() {
        this.State = EnumObjectState.Paused;
    }

    protected virtual void OnResume()
    {
        this.State = EnumObjectState.Resume;
    }

    protected virtual void OnUpdate(float deltaTime) {
        
    }
    protected virtual void OnRelease()
    {
        this.State = EnumObjectState.None;
        this.OnPlayCloseUIAudio();
    }
    protected virtual void OnLoadData() { }
    /// <summary>
    /// 
    /// </summary>
    protected virtual void OnPlayOpenUIAudio() { }
    /// <summary>
    /// 
    /// </summary>
    protected virtual void OnPlayCloseUIAudio() { }

    protected virtual void SetUI(params object[] uiParams)
    {
        this.State = EnumObjectState.Loading;
    }

    public void SetUIWhenOpening(params object[] uiParams)
    {
        SetUI(uiParams);
        StartCoroutine(LoadDataAsync());
    }

    private IEnumerator LoadDataAsync()
    {
        yield return new WaitForSeconds(0);
        if(this.State == EnumObjectState.Loading)
        {
            this.OnLoadData();
            this.State = EnumObjectState.Ready;
        }
    }
}
