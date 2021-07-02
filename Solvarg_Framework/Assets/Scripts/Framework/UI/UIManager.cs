using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Defines;

public class UIManager : Singleton<UIManager>
{

    private Dictionary<Defines.EnumUIName, GameObject> dicOpenUIs = null;

    private Stack<UIInfoData> stackOpenUIs = null;

    private GameObject _UIParent;
    public GameObject UIParent => (_UIParent);

    public async override void Awake()
    {
        Debuger.Log("初始化UI模块");
        dicOpenUIs = new Dictionary<Defines.EnumUIName, GameObject>();
        stackOpenUIs = new Stack<UIInfoData>();

        //创建UI全局界面
        _UIParent = await singletonManager.InstantiateAsync(UIPathDefines.UI_MAIN);
        _UIParent.transform.parent = singletonManager.transform;
        GameObject eventSystem =  await singletonManager.InstantiateAsync(UIPathDefines.EVENTSYSTEM);
        eventSystem.transform.parent = singletonManager.transform;
    }

    public T GetUI<T>(Defines.EnumUIName _uiType) where T:BaseUI
    {
        GameObject _retObj = GetUIObject(_uiType);
        if (_retObj != null)
        {
            return _retObj.GetComponent<T>();
        }
        return null;
    }

    public GameObject GetUIObject(Defines.EnumUIName _uiType)
    {
        GameObject _retObj=null;
        if(!dicOpenUIs.TryGetValue(_uiType,out _retObj))
        {
            throw new Exception("_dicOpenUIs TryGetValue Failure! _uiType: " + _uiType.ToString());
        }
        return _retObj;
    }

    public async Task OpenUI(EnumUIName[] _uiTypes)
    {
        await OpenUI(false, _uiTypes, null);
    }

    public async Task OpenUI(EnumUIName _uiType,params object[] _uiParams)
    {
        EnumUIName[] _uiTypes = new EnumUIName[1];
        _uiTypes[0] = _uiType;
        await OpenUI(false, _uiTypes, _uiParams);
    }

    public async void OpenUICloseOthers(EnumUIName[] _uiTypes)
    {
        await OpenUI(true, _uiTypes, null);
    }

    public async void OpenUICloseOthers(EnumUIName _uiType,params object[] _uiParams)
    {
        EnumUIName[] _uiTypes = new EnumUIName[1];
        _uiTypes[0] = _uiType;
        await OpenUI(true, _uiTypes, _uiParams);
    }

    public async Task OpenUI(bool _isCloseOthers,EnumUIName[] _uiTypes,params object[] _uiParams)
    {
        if (_isCloseOthers)
        {
            //CloseOtherUI
            CloseUIAll();
        }

        //push _uiTypes in stack.
        for(int i = 0; i < _uiTypes.Length; ++i)
        {
            EnumUIName _uiType = _uiTypes[i];
            if (!dicOpenUIs.ContainsKey(_uiType))
            {
                string _path = singletonManager.GetUIConfig(_uiType).Path;
                stackOpenUIs.Push(new UIInfoData(_uiType,_path,_uiParams));
            }
        }

        if (stackOpenUIs.Count > 0)
        {
            //打开UI
            await AsyncLoadData();
        }
    }
    public void CloseUI(EnumUIName _uiType)
    {
        GameObject _uiObj = GetUIObject(_uiType);
        if (_uiObj == null)
        {
            dicOpenUIs.Remove(_uiType);
        }
        else
        {
            BaseUI _baseUI = _uiObj.GetComponent<BaseUI>();
            if (_baseUI == null)
            {
                GameObject.Destroy(_uiObj);
                dicOpenUIs.Remove(_uiType);
            }
            else
            {
                _baseUI.StateChanged += CloseUIHandler;
                _baseUI.Release();
            }
        }
    }

    public void CloseUIAll()
    {
        List<EnumUIName> _listKey =new List<EnumUIName>(dicOpenUIs.Keys);
        foreach(var _uiType in _listKey)
        {
            CloseUI(_uiType);
        }
        CloseUI(_listKey.ToArray());
        dicOpenUIs.Clear();
    }

    public void CloseUI(EnumUIName[] _uiTypes)
    {
        foreach(EnumUIName _uiType in _uiTypes)
        {
            CloseUI(_uiType);
        }
    }

    /// <summary>
    /// 关闭UI的委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="newState"></param>
    /// <param name="oldState"></param>
    public void CloseUIHandler(object sender,EnumObjectState newState,EnumObjectState oldState)
    {
        if(newState == EnumObjectState.Closing)
        {
            BaseUI _baseUI = sender as BaseUI;
            dicOpenUIs.Remove(_baseUI.GetUIType());
            _baseUI.StateChanged -= CloseUIHandler;
        }
    }

    /// <summary>
    /// 实例化UI
    /// </summary>
    /// <returns></returns>
    private async Task<int> AsyncLoadData()
    {
        UIInfoData _uiInfoData = null;

        UnityEngine.Object _prefab = null;
        GameObject _uiObj = null;

        if (stackOpenUIs != null && stackOpenUIs.Count > 0)
        {
            do
            {
                _uiInfoData = stackOpenUIs.Pop();
                _prefab = await singletonManager.InstantiateAsync(_uiInfoData.Path);
                if (_prefab != null)
                {
                    _uiObj = _prefab as GameObject;
                    _uiObj.transform.parent = UIParent.transform;
                    _uiObj.transform.localPosition = Vector3.zero;
                    _uiObj.transform.localScale = Vector3.one;
                    BaseUI _baseUI = _uiObj.GetComponent<BaseUI>();
                    if (_baseUI == null)
                    {
                        _baseUI = _uiObj.AddComponent(_uiInfoData.ScriptType) as BaseUI;
                    }
                    if (_baseUI != null)
                    {
                        _baseUI.SetUIWhenOpening(_uiInfoData.UIParams);
                    }
                    dicOpenUIs.Add(_uiInfoData.UIType, _uiObj);
                }
            } while (stackOpenUIs.Count > 0);
        }

        return 0;
    }

    public void PauseOther(EnumUIName _uiType)
    {
        foreach(var tp in dicOpenUIs)
        {
            if (tp.Key != _uiType)
            {
                tp.Value.GetComponent<BaseUI>().Pause();
            }
        }
    }

    public void Resume(EnumUIName _uiType)
    {
        dicOpenUIs[_uiType].GetComponent<BaseUI>().Resume();
    }

    #region 预加载
    public async Task PreLoadUI(EnumUIName[] _uiTypes)
    {
        foreach (var _uiType in _uiTypes)
        {
            await PreLoadUI(_uiType);
        }
    }
    public async Task<GameObject> PreLoadUI(EnumUIName _uiType)
    {
        string path = singletonManager.GetUIConfig(_uiType).Path;
        GameObject obj =  await singletonManager.InstantiateAsync(path);
        obj.transform.parent = UIParent.transform;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        return obj;
    }
    #endregion

}
