using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RolePart
{
    public PlayerSide roleSide;
    public Transform rolePos;
    public string roleParams;//冗余字段,用于扩展传参
}

[Serializable]
public class ModelPart
{
    public string modelId;
    public Transform modelPos;
}

[Serializable]
public class TagPart
{
    public string tagName;
    public Transform tagPos;
    public string tagParams;//用于扩展传参
}

[Serializable]
public class CameraPart
{
    public Transform cameraPos;
}

public class SceneGlobalControl : MonoBehaviour
{
    private static SceneGlobalControl _inst;
    public static SceneGlobalControl Instance
    {
        get
        {
            return _inst;
        }
    }
    private void Awake()
    {
        _inst = this;
    }
    public List<RolePart> rolePart;

    public List<ModelPart> modelPart;

    public List<TagPart> tagPart;

    public CameraPart cameraPart;
}
