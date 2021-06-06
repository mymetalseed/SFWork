using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Defines;

public partial class SingletonManager
{
    #region 预加载UI
    /// <summary>
    /// 预加载UI
    /// </summary>
    /// <param name="_uiType"></param>
    public void PreloadUI(EnumUIType _uiType)
    {
        uiManager.PreLoadUI(_uiType);
    }
    /// <summary>
    /// 预加载UI组
    /// </summary>
    /// <param name="_uiType"></param>
    public void PreloadUI(EnumUIType[] _uiType)
    {
        uiManager.PreLoadUI(_uiType);
    }
    #endregion

    #region 打开UI
    public void OpenUI(EnumUIType _uiType)
    {
        uiManager.OpenUI(_uiType,null);
    }
    public void OpenUI(EnumUIType _uiType,params object[] _uiParams)
    {
        uiManager.OpenUI(_uiType, _uiParams);
    }
    public void OpenUI(EnumUIType[] _uiTypes)
    {
        uiManager.OpenUI(_uiTypes);
    }
    public void OpenUI(bool isClosethers,EnumUIType[] _uiTypes,params object[] _uiParams)
    {
        uiManager.OpenUI(isClosethers,_uiTypes, _uiParams);
    }

    public void OpenUICloseOthers(EnumUIType[] _uiTypes)
    {
        OpenUI(true, _uiTypes, null);
    }
    public void OpenUICloseOthers(EnumUIType _uiType, params object[] _uiParams)
    {
        EnumUIType[] _uiTypes = new EnumUIType[1];
        _uiTypes[0] = _uiType;
        OpenUI(true, _uiTypes, _uiParams);
    }
    #endregion

    #region 关闭UI
    public void CloseUI(EnumUIType _uiType)
    {
        uiManager.CloseUI(_uiType);
    }

    public void CloseUIAll()
    {
        uiManager.CloseUIAll();
    }
    public void CloseUI(EnumUIType[] _uiTypes)
    {
        uiManager.CloseUI(_uiTypes);
    }

    #endregion

    #region 停止所有UI
    #endregion

    #region 获取UI
    public T GetUI<T>(Defines.EnumUIType _uiType) where T : BaseUI
    {
        return uiManager.GetUI<T>(_uiType);
    }
    public GameObject GetUIObject(Defines.EnumUIType _uiType)
    {
        return GetUIObject(_uiType);
    }
    #endregion

    #region 全局提示UI - Dialog
    private UIDialog dialogUI;
    /// <summary>
    /// 打开提示框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <param name="button1Txt"></param>
    /// <param name="button2Txt"></param>
    /// <param name="closeAction"></param>
    /// <param name="btn1Action"></param>
    /// <param name="btn2Action"></param>
    public void OpenDialog(string title, string content, string button1Txt = "", string button2Txt = "", UnityAction closeAction = null, UnityAction btn1Action = null, UnityAction btn2Action = null)
    {
        dialogUI.Open(title, content, button1Txt, button2Txt, closeAction, btn1Action, btn2Action);
    }
    /// <summary>
    /// 预加载阶段配置Dialog
    /// </summary>
    /// <param name="dialog"></param>
    public void SetDialog(UIDialog dialog)
    {
        dialog.gameObject.transform.parent = uiManager.UIParent.transform;
        dialog.transform.localPosition = Vector3.zero;
        dialog.gameObject.SetActive(false);
        this.dialogUI = dialog;
    }
    #endregion

}
