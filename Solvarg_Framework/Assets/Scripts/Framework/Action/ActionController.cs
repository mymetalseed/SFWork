using SolvargAction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : BaseController
{
    #region 参数
    bool _IsPlaying;
    public bool IsPlaying => (_IsPlaying);

    private bool isReady = true;
    public bool IsReady => (isReady);

    #endregion

    #region Action相关属性
    private SF_ActionGraph currentActionGraph;
    #endregion

    public async override void OnStart(BaseCreature role)
    {
        SF_ActionGraph graph = await SingletonManager.Instance.GetActionGraphByRid(role.info.ID);
        RegisterActionGraph(graph);
        StartActionGraph();
    }

    /// <summary>
    /// 向角色注册Action集合
    /// </summary>
    /// <param name="actionGraph"></param>
    public void RegisterActionGraph(SF_ActionGraph actionGraph)
    {
        currentActionGraph?.StopActionGraph();
        actionGraph.controller = this;
        currentActionGraph = actionGraph;
        currentActionGraph?.InitGraph(owner);
    }

    /// <summary>
    /// 开始助兴ActionGraph
    /// </summary>
    public void StartActionGraph()
    {
        currentActionGraph?.StartActionGraph();
    }

    public override void OnUpdate()
    {
        currentActionGraph?.Update();
    }

}
