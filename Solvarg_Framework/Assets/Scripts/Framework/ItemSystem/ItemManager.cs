using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Item将来会延伸出物品,武器,药品等等一系列的东西
/// 但是这些物品在背包中是有数量的,这个职责分离吧
/// Item不管数量,只管Item本身
/// 
/// ItemManager将作为Item工厂来生产Item
/// </summary>
public class ItemManager : Singleton<ItemManager>
{
    Dictionary<string, ItemInfo> items;

    /// <summary>
    /// 初始化物品信息
    /// </summary>
    /// <param name="infos"></param>
    public void InitItemInfo(List<ItemInfo> infos)
    {
        items = new Dictionary<string, ItemInfo>();
        foreach(ItemInfo i in infos)
        {
            items.Add(i.ID,i);
        }
    }

    /// <summary>
    /// 工厂方法,根据物品Id获取物品
    /// TODO: 
    /// 后面可能会出现的需求: 
    /// 根据物品Id获取物品,但是没有传递泛型,需要根据物品类型来进行泛型判断
    /// 背包系统肯定需要
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public async Task<T> GetItem<T>(string itemId) where T: ItemBase, new()
    {
        return await ItemBase.GetItem<T>(items[itemId]); 
    }

    #region Unity Callback
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
