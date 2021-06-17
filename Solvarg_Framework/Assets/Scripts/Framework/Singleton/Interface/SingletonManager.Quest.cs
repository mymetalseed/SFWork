using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 配置任务信息
    /// </summary>
    /// <param name="questInfo"></param>
    public void SetQuestInfo(Dictionary<string,List<QuestInfo>> questInfo)
    {
        questManager.SetQuestInfo(questInfo);
    }


}
