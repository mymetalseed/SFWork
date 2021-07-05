using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityEngineExtension
{
    public delegate void CallBack();

    /// <summary>
    /// 下一帧执行
    /// </summary>
    /// <param name="_mb"></param>
    /// <param name="callback"></param>
    public static void InvokeNextFrame(this MonoBehaviour _mb,CallBack callback)
    {
        _mb.StartCoroutine(ProcessNextFrame(callback));
    }

    private static IEnumerator ProcessNextFrame(CallBack callback)
    {
        yield return null;
        callback();
    }
}
