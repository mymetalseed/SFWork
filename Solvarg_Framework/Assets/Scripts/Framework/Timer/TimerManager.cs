using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : Singleton<TimerManager>
{
    private List<Timer> listTimer = new List<Timer>();
    private List<Timer> listLocalPauseTimer = new List<Timer>();

    private float globalPauseOffsetTime;

    private bool isGlobalPause = false;

    public bool IsGlobalPause
    {
        get
        {
            return isGlobalPause;
        }
        private set
        {
            isGlobalPause = value;
        }
    }

    public override void Awake()
    {
        Debuger.Log("初始化Timer模块");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.playModeStateChanged += (UnityEditor.PlayModeStateChange state) =>
        {
            if (UnityEditor.EditorApplication.isPaused)
            {
                PauseAll();

            }
            else if (UnityEditor.EditorApplication.isPlaying)
            {
                ResumeAll();
            }
        };
#endif    
    }

    public override void Update()
    {
        for (int i = 0; i < listTimer.Count; ++i)
        {
            listTimer[i].Update();
        }
    }

    public void PauseAll()
    {
        if (IsGlobalPause) return;

        IsGlobalPause = true;

        listLocalPauseTimer = new List<Timer>();
        for (int i = 0; i < listTimer.Count; ++i)
        {
            if (listTimer[i].State == EnumTimerState.Pause && !listLocalPauseTimer.Contains(listTimer[i]))
                listLocalPauseTimer.Add(listTimer[i]);

            listTimer[i].Pause();
        }
    }

    public void ResumeAll()
    {
        if (!IsGlobalPause) return;

        IsGlobalPause = false;

        for (int i = 0; i < listTimer.Count; ++i)
        {
            if (!listLocalPauseTimer.Contains(listTimer[i]))
            {
                listTimer[i].Resume();
            }
        }
    }

    public Timer Register(float _duration, TimerCompleteHandler onCompelte = null, TimerUpdateHandler onUpdate = null, bool _isIgnoreTimeScale = true,
        bool _isRepeate = false, TimerCheckInterruptHandler _onCheckInterrupt = null, TimerInterruptHandler _onInterrupt = null, bool _isAutoDestroy = true)
    {
        Timer timer = new Timer(_duration, onCompelte, onUpdate, _isIgnoreTimeScale, _isRepeate, _onCheckInterrupt, _onInterrupt, _isAutoDestroy);
        Register(timer);
        return timer;
    }

    public void Register(Timer _timer)
    {
        if (listTimer.Contains(_timer)) return;

        if (_timer.State == EnumTimerState.Destroy)
        {
            Debug.LogError("Can not register a destoyed timer");
            return;
        }

        listTimer.Add(_timer);
        _timer.onPause += () => { if (TimerManager.Instance.IsGlobalPause && _timer.State == EnumTimerState.Pause && !listLocalPauseTimer.Contains(_timer)) listLocalPauseTimer.Add(_timer); };
        _timer.onResume += () => { if (listLocalPauseTimer.Contains(_timer)) { listLocalPauseTimer.Remove(_timer); } };
        _timer.onDestroy += () => UnRegister(_timer);
    }

    public void UnRegister(Timer _timer)
    {
        if (listTimer.Contains(_timer))
            listTimer.Remove(_timer);
    }

    void OnApplicationPause(bool _isPause)
    {
        if (_isPause)
        {
            PauseAll();
        }
        else
        {
            ResumeAll();
        }
    }
}