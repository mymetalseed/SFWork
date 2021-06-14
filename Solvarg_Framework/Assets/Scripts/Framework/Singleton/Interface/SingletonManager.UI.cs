using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public async Task<GameObject> PreloadUI(EnumUIName _uiType)
    {
        return await uiManager.PreLoadUI(_uiType);
    }
    /// <summary>
    /// 预加载UI组
    /// </summary>
    /// <param name="_uiType"></param>
    public async Task PreloadUI(EnumUIName[] _uiType)
    {
        await uiManager.PreLoadUI(_uiType);
    }
    #endregion

    #region 打开UI
    public async Task OpenUI(EnumUIName _uiType)
    {
        await uiManager.OpenUI(_uiType,null);
    }
    public async Task OpenUI(EnumUIName _uiType,params object[] _uiParams)
    {
        await uiManager.OpenUI(_uiType, _uiParams);
    }
    public async Task OpenUI(EnumUIName[] _uiTypes)
    {
        await uiManager.OpenUI(_uiTypes);
    }
    public void OpenUI(bool isClosethers,EnumUIName[] _uiTypes,params object[] _uiParams)
    {
        uiManager.OpenUI(isClosethers,_uiTypes, _uiParams);
    }

    public void OpenUICloseOthers(EnumUIName[] _uiTypes)
    {
        OpenUI(true, _uiTypes, null);
    }
    public void OpenUICloseOthers(EnumUIName _uiType, params object[] _uiParams)
    {
        EnumUIName[] _uiTypes = new EnumUIName[1];
        _uiTypes[0] = _uiType;
        OpenUI(true, _uiTypes, _uiParams);
    }
    #endregion

    #region 关闭UI
    public void CloseUI(EnumUIName _uiType)
    {
        uiManager.CloseUI(_uiType);
    }

    public void CloseUIAll()
    {
        uiManager.CloseUIAll();
    }
    public void CloseUI(EnumUIName[] _uiTypes)
    {
        uiManager.CloseUI(_uiTypes);
    }

    #endregion

    #region 停止所有UI
    #endregion

    #region 获取UI
    public T GetUI<T>(Defines.EnumUIName _uiType) where T : BaseUI
    {
        return uiManager.GetUI<T>(_uiType);
    }
    public GameObject GetUIObject(Defines.EnumUIName _uiType)
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
    public void OpenDialog(string title, string content, string button1Txt = "", string button2Txt = "", UnityAction closeAction = null, UnityAction btn1Action = null)
    {
        dialogUI.Open(title, content, button1Txt, button2Txt, closeAction, btn1Action);
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

    #region 过场UI - Progress
    private UIProgress progressUI;
    public UIProgress ProgressUIInstance => (progressUI);

    /// <summary>
    /// 加载过场UI
    /// </summary>
    public async Task LoadProgressUI()
    {
        UIConfig uIConfig = SingletonManager.Instance.GetUIConfig(EnumUIName.Progress);
        progressUI = (await InstantiateAsync(uIConfig.Path)).GetComponent<UIProgress>();
        SetProgressUI();
    }

    /// <summary>
    /// 打开ProgressUI
    /// </summary>
    public void OpenProgressUI()
    {
        progressUI.Open();
    }

    /// <summary>
    /// 配置ProgressUI
    /// </summary>
    /// <param name="progress"></param>
    private void SetProgressUI()
    {
        progressUI.gameObject.transform.parent = uiManager.UIParent.transform;
        progressUI.transform.localPosition = Vector3.zero;
        progressUI.gameObject.SetActive(false);
    }
    #endregion
}
