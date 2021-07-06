using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TweenHelper
{
    public static Tweener MoveTo(this Transform trans,
            Vector3 pos,
            float time,
            TweenCallback startCallback = null,
            TweenCallback completeCallback = null,
            TweenCallback updateCallback = null,
            float delaySeconds = 0,
            Ease ease = Ease.Linear
        )
    {
        return trans.DOLocalMove(pos, time).OnStart(startCallback).OnComplete(completeCallback).OnUpdate(updateCallback).SetDelay(delaySeconds).SetEase(ease);
    }

    public static Sequence MoveScaleTo(Transform t, 
            Vector3 scale, Vector3 pos, float time,
            TweenCallback startCallback = null,
            TweenCallback completeCallback = null,
            TweenCallback updateCallback = null,
            float delaySeconds = 0,
            Ease ease = Ease.Linear
        )
    {
        Sequence mySequesce = DOTween.Sequence();
        mySequesce.Insert(0, t.DOLocalMove(pos, time));
        mySequesce.Insert(0, t.DOScale(scale, time));
        mySequesce.OnStart(startCallback);
        mySequesce.OnComplete(completeCallback);
        mySequesce.OnUpdate(updateCallback);
        mySequesce.SetDelay(delaySeconds);
        mySequesce.SetEase(ease);
        return mySequesce;
    }

    public static Tweener ScaleTo(Transform t, 
            Vector3 scale, float time,
            TweenCallback startCallback = null,
            TweenCallback completeCallback = null,
            TweenCallback updateCallback = null,
            float delaySeconds = 0, Ease ease = Ease.Linear, int loops = 1
        )
    {
        return t.DOScale(scale, time).OnStart(startCallback).OnComplete(completeCallback).OnUpdate(updateCallback).SetDelay(delaySeconds).SetEase(ease).SetLoops(loops);
    }

    public static Tweener RotateTo(Transform t, 
            Vector3 rot, float time, RotateMode rotateMode = RotateMode.Fast,
            TweenCallback startCallback = null,
            TweenCallback completeCallback = null,
            TweenCallback updateCallback = null,
            float delaySeconds = 0, Ease ease = Ease.Linear
        )
    {
        return t.DOLocalRotate(rot, time, rotateMode).OnStart(startCallback).OnComplete(completeCallback).OnUpdate(updateCallback).SetDelay(delaySeconds).SetEase(ease);
    }

    public static Tweener FadeOut(CanvasGroup cg, float time, float delaySeconds)
    {
        /*
        TweenParms tp = new TweenParms();
        tp.Prop("alpha", 0);
        tp.Delay(delaySeconds);
        tp.Ease(EaseType.Linear);
        return HOTween.To(go, time, tp);
        */
        return cg.DOFade(0, time).SetDelay(delaySeconds);
    }

    public static Tweener FadeIn(CanvasGroup cg, float time, float delaySeconds)
    {
        return cg.DOFade(1, time).SetDelay(delaySeconds);
    }

    public static void KillTween(Transform t)
    {
        t.DOKill();
    }

}
