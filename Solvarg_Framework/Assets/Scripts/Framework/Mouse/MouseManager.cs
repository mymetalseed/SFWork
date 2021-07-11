using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : Singleton<MouseManager>, IApplication
{
    #region 参数
    RaycastHit hitInfo;
    public event Action<Vector3> OnMouseClicked;
    public event Action<GameObject> OnEnemyClicked;
    private string configPath = "Assets/AssetPackage/Config/MouseConfig.asset";
    private MouseConfig mouseConfig;
    private bool isInitialized = false;
    #endregion

    #region 功能
    void SetCursorTexture()
    {
        Ray ray = singletonManager.MainCamera.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray,out hitInfo))
        {
            switch (hitInfo.collider.gameObject.tag)
            {
                //这里实现鼠标指针切换
                default:
                    break;
            }
        }
        
    }
    void MouseControl()
    {
        
        if (Input.GetMouseButtonDown(0) && hitInfo.collider != null)
        {
            //触发Invoke,但是这里先空着,似乎没啥必要
        }
        
    }



    #endregion

    #region Unity Callback
    public async override void Awake()
    {
        base.Awake();
        isInitialized = false;
        mouseConfig = await singletonManager.LoadAsset<MouseConfig>(configPath);
        Cursor.SetCursor(mouseConfig.normal, new Vector2(16, 16), CursorMode.Auto);
        isInitialized = true;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnGUI()
    {
        base.OnGUI();
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
        if (isInitialized && singletonManager.MainCamera != null)
        {
            SetCursorTexture();
            MouseControl();
        }
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }

    public void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.SetCursor(mouseConfig.normal, new Vector2(16, 16), CursorMode.Auto);
        }
    }

    public void OnApplicationPause(bool pause)
    {

    }
    #endregion
}
