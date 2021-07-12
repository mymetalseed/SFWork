using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UXExtension
{
    /// <summary>
    /// 水下微浮动
    /// </summary>
    /// <param name="trans"></param>
    public static void FloatInWater(this Transform trans,float offsetY=5)
    {
        var pos = trans.localPosition.y + offsetY;
        trans.DOLocalMoveY(pos, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="trans"></param>
    public static void StarsRotate_1(this Transform trans)
    {
        trans.DORotate(new Vector3(0, 0, -79.2f), 20f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.OutQuad);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="trans"></param>
    public static void StarsRotate_2(this Transform trans)
    {
        trans.DORotate(new Vector3(0, 0, 379.2f), 20f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.InSine);
    }

    public static void SlowFade_Show(this Image img)
    {
        img.DOFade(0.45f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutBounce);
    }

    public static void SlowScale(this Transform trans)
    {
        trans.DOScale(1.1f, 1.8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

    public static void CameraShake(this Camera camera,float duration = 0.25f)
    {
        camera.DOShakePosition(duration, fadeOut: false,
            strength: 0.08f,
            vibrato: 30).SetEase(Ease.InQuint);
    }
}
