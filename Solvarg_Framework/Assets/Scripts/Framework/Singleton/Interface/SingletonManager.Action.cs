using SolvargAction;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class SingletonManager
{
    /// <summary>
    /// 通过角色Id获取该角色所有的行为
    /// </summary>
    /// <param name="rid"></param>
    /// <returns></returns>
    public async Task<SF_ActionGraph> GetActionGraphByRid(string rid)
    {
        return await actionManager.GetActionGraphByRid(rid);
    }

    /// <summary>
    /// 通过ActionInfo获取ActionGraph
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    public async Task<SF_ActionGraph> GetActionGraph(ActionListInfo info)
    {
        return await actionManager.GetActionGraph(info);
    }

    /// <summary>
    /// 获取所有该角色的行为资源路径
    /// </summary>
    /// <param name="rid"></param>
    /// <returns></returns>
    public List<ActionListInfo> GetActionListInfoByRid(string rid)
    {
        return actionManager.GetActionListInfoByRid(rid);
    }

}
