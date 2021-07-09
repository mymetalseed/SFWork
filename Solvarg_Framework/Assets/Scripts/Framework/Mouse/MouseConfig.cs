using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MouseConfig",menuName ="Solvarg/Mouse")]
public class MouseConfig : ScriptableObject
{
    [Label("标准指针")]
    [ShowAssetPreview]
    public Texture2D normal;
    [Label("离开/进入下一关指针")]
    [ShowAssetPreview]
    public Texture2D doorWay;
    [Label("攻击指针")]
    [ShowAssetPreview]
    public Texture2D attack;
    [Label("指向目标指针")]
    [ShowAssetPreview]
    public Texture2D target;
    [Label("选定指针")]
    [ShowAssetPreview]
    public Texture2D select;
}
