using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ActionListInfo
{
    [AllowNesting]
    [Label("行为集名称")]
    public string actionName;
    [AllowNesting]
    [Label("行为集Id")]
    public string actionId;
    [AllowNesting]
    [Label("行为集对应角色Id")]
    public string roleId;
    [AllowNesting]
    [Label("行为集资源路径")]
    public string path;
}

[CreateAssetMenu(fileName = "ActionConfig", menuName = "Solvarg/ActionConfig")]
public class ActionConfig : ScriptableObject
{
    [Foldout("行为集列表")]
    [Label("行为集列表")]
    [ReorderableList]
    public List<ActionListInfo> infoList;

    /// <summary>
    /// ActionId -Action
    /// </summary>
    [HideInInspector]
    public Dictionary<string, ActionListInfo> infoDict;
    /// <summary>
    /// RoleId - ActionList
    /// </summary>
    [HideInInspector]
    public Dictionary<string, List<ActionListInfo>> roleActionDict;

    /// <summary>
    /// 运行时初始化
    /// </summary>
    public void DoInit()
    {
        infoDict = new Dictionary<string, ActionListInfo>();
        roleActionDict = new Dictionary<string, List<ActionListInfo>>();
        foreach (ActionListInfo ali in infoList)
        {
            if (infoDict.ContainsKey(ali.actionId))
            {
                Debuger.LogError("出现重复行为集ID");
            }
            else
            {
                infoDict.Add(ali.actionId, ali);
            }

            if (roleActionDict.ContainsKey(ali.roleId))
            {
                roleActionDict[ali.roleId].Add(ali);
            }
            else
            {
                roleActionDict.Add(ali.roleId,new List<ActionListInfo>());
                roleActionDict[ali.roleId].Add(ali);
            }
        }
    }

}
