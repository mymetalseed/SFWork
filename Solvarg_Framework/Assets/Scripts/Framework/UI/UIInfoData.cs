using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfoData
{
    public Defines.EnumUIName UIType { get; private set; }
    public Type ScriptType { get; private set; }
    public string Path { get; private set; }
    public object[] UIParams { get; private set; }
    public UIInfoData(Defines.EnumUIName _uiType,string _path,object[] _uiParams)
    {
        UIType = _uiType;
        Path = _path;
        UIParams = _uiParams;
        this.ScriptType = UIPathDefines.GetUIScriptByType(this.UIType);
    }
}
