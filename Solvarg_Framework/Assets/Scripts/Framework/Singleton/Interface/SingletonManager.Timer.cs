using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SingletonManager
{
    public Timer Timer_Register(float _duration, TimerCompleteHandler onCompelte = null, TimerUpdateHandler onUpdate = null, bool _isIgnoreTimeScale = true,
    bool _isRepeate = false, TimerCheckInterruptHandler _onCheckInterrupt = null, TimerInterruptHandler _onInterrupt = null, bool _isAutoDestroy = true)
    {
        Timer timer = timerManager.Register(_duration, onCompelte, onUpdate, _isIgnoreTimeScale, _isRepeate, _onCheckInterrupt, _onInterrupt, _isAutoDestroy);
        return timer;
    }
}
