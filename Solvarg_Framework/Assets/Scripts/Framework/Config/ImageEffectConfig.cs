using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum ImageEffectType {
    None=-1,
    Clock_1,//钟1
    Clock_2,//钟2
    Clock_3,//钟3
    MaskFade,//遮罩渐变
    Blinds_1,//百叶窗渐变1
    Blinds_2,//百叶窗渐变2,菱形擦除
    Blinds_3,//百叶窗渐变3
    Blinds_4,//百叶窗渐变4
    Blinds_5,//百叶窗渐变5
    Dissolve,//溶解
    Center_Seperate_1,//中心分离1
    Center_Seperate_2,//中心分离2
    Center_Combind,//中心合并
    Seperate_1,//切分
    Seperate_2,//中心切分
    Square,//圆形过渡
    RandomBlock_1,//随机块状擦除
    RandomBlock_2,//随机块状擦除2
    ThreeBillBoard,//3DBillBoard(可以做广告牌效果)
}

[Serializable]
public class ImageEffectInfo
{
    public ImageEffectType effectType;
    public Shader shader;
    public string name;
}

[CreateAssetMenu(menuName ="SFWork/ImageEffect",fileName ="ImageEffect")]
public class ImageEffectConfig : ScriptableObject
{
    [SerializeField]
    public List<ImageEffectInfo> imageEffect;

    private Dictionary<ImageEffectType, ImageEffectInfo> effectType=null;

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        effectType = new Dictionary<ImageEffectType, ImageEffectInfo>();
        if (imageEffect == null) return;
        foreach (ImageEffectInfo i in imageEffect)
        {
            effectType[i.effectType] = i;
        }
    }

    public ImageEffectInfo this[ImageEffectType type]{
        get
        {
            if (type == ImageEffectType.None) return null;
            if (effectType.ContainsKey(type))
            {
                return effectType[type];
            }
            else
            {
                Init();
                return effectType[type];
            }
        }
    }
}
