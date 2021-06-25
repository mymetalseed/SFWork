using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

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
    /// <summary>
    /// 标准camera的位置
    /// </summary>
    public Transform cameraPos;
    //public List<CINE>
    public CinemachineVirtualCameraBase playerCamera;
    
    [SerializeField]
    public List<Director> director;
    
    [Serializable]
    public class Director {
        public string tag;
        public CinemachineVirtualCameraBase camera;
    }

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

    public UnityAction UpdateAction;

    #region Unity Callback

    private void Update()
    {
        UpdateAction?.Invoke();
    }

    #endregion
}
