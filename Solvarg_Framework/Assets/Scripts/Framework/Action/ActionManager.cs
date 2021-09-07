using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolvargAction;
using System.Threading.Tasks;

public class ActionManager : Singleton<ActionManager>
{
    #region 参数
    public string ActionConfigPath = "Assets/AssetPackage/Config/ActionConfig.asset";
    private ActionConfig config;
    #endregion

    #region 功能
    /// <summary>
    /// 通过角色Id获取该角色所有的行为
    /// </summary>
    /// <param name="rid"></param>
    /// <returns></returns>
    public async Task<SF_ActionGraph> GetActionGraphByRid(string rid)
    {
        List<ActionListInfo> list = GetActionListInfoByRid(rid);
        if(list!=null && list.Count > 0)
        {
            return await GetActionGraph(list[0]);
        }
        return null;
    }

    /// <summary>
    /// 通过ActionInfo获取ActionGraph
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    public async Task<SF_ActionGraph> GetActionGraph(ActionListInfo info)
    {
        SF_ActionGraph entity = null;
        if (info != null) {
            var real = await singletonManager.LoadAsset<SF_ActionGraph>(info.path);
            real.StopActionGraph();
            entity = real.Copy() as SF_ActionGraph;
        }
        return entity;
    }

    /// <summary>
    /// 获取所有该角色的行为资源路径
    /// </summary>
    /// <param name="rid"></param>
    /// <returns></returns>
    public List<ActionListInfo> GetActionListInfoByRid(string rid)
    {
        return config.roleActionDict[rid];
    }

    #endregion


    #region Unity Callback
    public async override void Awake()
    {
        base.Awake();
        config = await singletonManager.LoadAsset<ActionConfig>(ActionConfigPath);
        config.DoInit();
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
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }
    #endregion
}
