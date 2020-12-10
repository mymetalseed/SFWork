using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{

    private Dictionary<Defines.EnumUIType, GameObject> dicOpenUIs = null;

    private Stack<UIInfoData> stackOpenUIs = null;
    public override void Awake()
    {
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

}
