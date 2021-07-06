using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 初始化物品信息
    /// </summary>
    /// <param name="infos"></param>
    public void InitItemInfo(List<ItemInfo> infos)
    {
        itemManager.InitItemInfo(infos);
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
    public async Task<T> GetItem<T>(string itemId) where T : ItemBase, new()
    {
        return await itemManager.GetItem<T>(itemId);
    }

}
