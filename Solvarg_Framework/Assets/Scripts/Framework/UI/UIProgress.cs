using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgress : BaseUI
{
    private Image backGroundImg;
    private Slider slider;
    private Image sliderBackImg;
    private Image sliderImg;
    private Image handleImg;
    private Text toolTip;
    public override Defines.EnumUIName GetUIType()
    {
        return Defines.EnumUIName.Progress;
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        backGroundImg = transform.Find("Background").GetComponent<Image>();
        slider = transform.Find("Bar").GetComponent<Slider>();
        sliderBackImg = transform.Find("Bar/Background").GetComponent<Image>();
        sliderImg = transform.Find("Bar/Fill Area/Fill").GetComponent<Image>();
        handleImg = transform.Find("Bar/Handle").GetComponent<Image>();
        toolTip = transform.Find("ToolTip").GetComponent<Text>();
    }

    public void Open()
    {
        this.gameObject.SetActive(true);
        //TODO 初始化
        toolTip.text = "";
        slider.value = 0f;
        this._state = Defines.EnumObjectState.Ready;
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
        if (Mathf.Abs(slider.value - 1.0f) < 1e-6)
        {
            CloseProgress();
        }
        //始终位于最上方
        this.transform.SetAsLastSibling();
    }


    public void SetProgressToolTip(string txt)
    {
        this.toolTip.text = txt;
    }

    public void CloseProgress()
    {
        //TODO: 预处理 清空数据
        this._state = Defines.EnumObjectState.Closing;
        Message message = new Message(MessageRouter.ProgressClose, this);
        SingletonManager.Instance.Message_FireAsync(message);
        this.gameObject.SetActive(false);
        toolTip.text = "";
        slider.value = 0f;

    }

    /// <summary>
    /// 通知预加载配置文件流程
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    public void NotifyConfigProgress(int index,int count)
    {
        //暂时占比50%
        float curPercent = (1.0f*index / count)/2f;
        slider.value = curPercent;
    }

    /// <summary>
    /// 通知预加载资源文件流程
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    public void NotifyAssetProgress(int index, int count)
    {
        //暂时占比50%
        float curPercent = 0.5f + ((1.0f*index / count) / 2f);

        slider.value = curPercent;
    }
}
