using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 物品的基类
/// </summary>
public abstract class ItemBase
{
    private ItemInfo _info;
    public ItemInfo ItemInfo => (_info);

    private ItemType type;
    public ItemType ItemType => (type);

    public Texture2D icon;
    public GameObject ItemModel;

    private ItemBase() { }
    public static async Task<T> GetItem<T>(ItemInfo info) where T : ItemBase,new()
    {
        T item = new T();
        item._info = info;
        item.type = info.Type;

        //初始化Icon
        item.icon = await SingletonManager.Instance.GetIconById(info.Icon);
        //判别是否有ModelId,有的话初始化Model
        if(info.ModelId!="" || info.ModelId != null)
        {
            item.ItemModel = await SingletonManager.Instance.GetModelById(info.ModelId);
        }
        return item;
    }

    /// <summary>
    /// 当使用该物体时将会触发的事件
    /// </summary>
    public abstract void Excute();

}
