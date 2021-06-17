using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// 方法接口集: Asset
/// </summary>
public partial class SingletonManager
{
    /// <summary>
    /// 加载单一资源(Addressable)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="assetPath">资源路径</param>
    /// <returns></returns>
    public async Task<T> LoadAsset<T>(string assetPath) where T : Object
    {
        return await assetManager.LoadAsset<T>(assetPath);
    }

    /// <summary>
    /// 异步加载Object,有回调函数
    /// </summary>
    /// <param name="assetPath"></param>
    /// <param name="complete"></param>
    public void InstantiateAsync(string assetPath, System.Action<AsyncOperationHandle<GameObject>> complete)
    {
        assetManager.InstantiateAsync(assetPath, complete);
    }

    public async Task<GameObject> InstantiateAsync(string assetPath,Transform parent=null)
    {
        GameObject obj = await assetManager.InstantiateAsync(assetPath, parent);
        return obj;
    }

}
