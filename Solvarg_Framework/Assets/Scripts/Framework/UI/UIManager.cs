using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Defines;

public class UIManager : Singleton<UIManager>
{

    private Dictionary<Defines.EnumUIType, GameObject> dicOpenUIs = null;

    private Stack<UIInfoData> stackOpenUIs = null;
    public override void Awake()
    {
        Debuger.Log("初始化UI模块");
        dicOpenUIs = new Dictionary<Defines.EnumUIType, GameObject>();
        stackOpenUIs = new Stack<UIInfoData>();
    }

    public T GetUI<T>(Defines.EnumUIType _uiType) where T:BaseUI
    {
        GameObject _retObj = GetUIObject(_uiType);
        if (_retObj != null)
        {
            return _retObj.GetComponent<T>();
        }
        return null;
    }

    public GameObject GetUIObject(Defines.EnumUIType _uiType)
    {
        GameObject _retObj=null;
        if(!dicOpenUIs.TryGetValue(_uiType,out _retObj))
        {
            throw new Exception("_dicOpenUIs TryGetValue Failure! _uiType: " + _uiType.ToString());
        }
        return _retObj;
    }

    public void OpenUI(EnumUIType[] _uiTypes)
    {
        OpenUI(false, _uiTypes, null);
    }

    public void OpenUI(EnumUIType _uiType,params object[] _uiParams)
    {
        EnumUIType[] _uiTypes = new EnumUIType[1];
        _uiTypes[0] = _uiType;
        OpenUI(false, _uiTypes, _uiParams);
    }

    public void OpenUICloseOthers(EnumUIType[] _uiTypes)
    {
        OpenUI(true, _uiTypes, null);
    }

    public void OpenUICloseOthers(EnumUIType _uiType,params object[] _uiParams)
    {
        EnumUIType[] _uiTypes = new EnumUIType[1];
        _uiTypes[0] = _uiType;
        OpenUI(true, _uiTypes, _uiParams);
    }

    public void OpenUI(bool _isCloseOthers,EnumUIType[] _uiTypes,params object[] _uiParams)
    {
        if (_isCloseOthers)
        {
            //CloseOtherUI
            CloseUIAll();
        }

        //push _uiTypes in stack.
        for(int i = 0; i < _uiTypes.Length; ++i)
        {
            EnumUIType _uiType = _uiTypes[i];
            if (!dicOpenUIs.ContainsKey(_uiType))
            {
                string _path = UIPathDefines.GetUIPrefabsPathByType(_uiType);
                stackOpenUIs.Push(new UIInfoData(_uiType,_path,_uiParams));
            }
        }

        if (stackOpenUIs.Count > 0)
        {
            //打开UI
            singletonManager.StartCoroutine(AsyncLoadData());
        }
    }
    public void CloseUI(EnumUIType _uiType)
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
        List<EnumUIType> _listKey =new List<EnumUIType>(dicOpenUIs.Keys);
        foreach(var _uiType in _listKey)
        {
            CloseUI(_uiType);
        }
        CloseUI(_listKey.ToArray());
        dicOpenUIs.Clear();
    }

    public void CloseUI(EnumUIType[] _uiTypes)
    {
        foreach(EnumUIType _uiType in _uiTypes)
        {
            CloseUI(_uiTypes);
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
    private IEnumerator<int> AsyncLoadData()
    {
        UIInfoData _uiInfoData = null;

        UnityEngine.Object _prefab = null;
        GameObject _uiObj = null;

        if (stackOpenUIs != null && stackOpenUIs.Count > 0)
        {
            do
            {
                _uiInfoData = stackOpenUIs.Pop();
                _prefab = Resources.Load(_uiInfoData.Path);
                if (_prefab != null)
                {
                    _uiObj = MonoBehaviour.Instantiate(_prefab) as GameObject;
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

        yield return 0;
    }


    #region 预加载
    public void PreLoadUI(EnumUIType[] _uiTypes)
    {
        foreach (var _uiType in _uiTypes)
        {
            PreLoadUI(_uiType);
        }
    }
    public void PreLoadUI(EnumUIType _uiType)
    {
        string path = UIPathDefines.GetUIPrefabsPathByType(_uiType);
        Resources.Load(path);
    }
    #endregion

}
