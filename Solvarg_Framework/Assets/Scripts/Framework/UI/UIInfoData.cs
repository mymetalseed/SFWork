using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfoData
{
    public Defines.EnumUIType UIType { get; private set; }
    public string Path { get; private set; }
    public object[] UIParams { get; private set; }
    UIInfoData(Defines.EnumUIType _uiType,string _path,object[] _uiParams)
    {
        UIType = _uiType;
        Path = _path;
        UIParams = _uiParams;
    }
}
