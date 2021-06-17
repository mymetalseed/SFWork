using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    #region 任务数据库缓存
    private Dictionary<string, List<QuestInfo>> originData;
    private Dictionary<string, Dictionary<string, QuestInfo>> questMap;

    /// <summary>
    /// 初始化任务信息
    /// </summary>
    /// <param name="questInfo"></param>
    public void SetQuestInfo(Dictionary<string, List<QuestInfo>> questInfo)
    {
        originData = questInfo;
        questMap = new Dictionary<string, Dictionary<string, QuestInfo>>();
        foreach(var info in questInfo)
        {
            if (!questMap.ContainsKey(info.Key))
            {
                questMap.Add(info.Key,new Dictionary<string, QuestInfo>());
            }
            for(int i = 0; i < info.Value.Count; ++i)
            {
                questMap[info.Key].Add(info.Value[i].ID, info.Value[i]);
            }
        }
    }
    #endregion

    #region 任务实际存储
    //当前的边缘任务
    private List<KeyValuePair<string, QuestBase>> currentEdgeQuest;
    /// <summary>
    /// 获取所有初始任务根节点
    /// </summary>
    /// <returns></returns>
    public List<QuestInfo> GetFirstQuestList()
    {
        List<QuestInfo> root = new List<QuestInfo>();

        foreach (var quest in questMap)
        {
            root.Add(quest.Value["-1"]);
        }

        return root;
    }

    /// <summary>
    /// 首次初始化任务集
    /// </summary>
    public void InitQuest()
    {
        List<QuestInfo> first = GetFirstQuestList();
        for(int i = 0; i < first.Count; ++i)
        {
            
        }
    }

    #endregion

    #region Unity CallBack
    public override void Awake()
    {
        base.Awake();

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
