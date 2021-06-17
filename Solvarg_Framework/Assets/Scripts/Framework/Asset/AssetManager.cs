using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class AssetManager : Singleton<AssetManager>
{
    public override void Awake()
    {
        base.Awake();

    }

    public async Task<T> LoadAsset<T>(string assetPath) where T: Object
    {
        AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetPath);
        T Result = await handle.Task;
        //ReleaseAsset(handle);
        return Result;
    }

    public void InstantiateAsync(string assetPath, System.Action<AsyncOperationHandle<GameObject>> complete)
    {
        Addressables.InstantiateAsync(assetPath).Completed += complete;
    }

    public async Task<GameObject> InstantiateAsync(string assetPath,Transform parent=null)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetPath, parent);
        GameObject Result = await handle.Task;
        //ReleaseAsset(handle);
        return Result;
    }

    /// <summary>
    /// 释放句柄
    /// </summary>
    /// <param name="handle"></param>
    public void ReleaseAsset(AsyncOperationHandle handle)
    {
        Addressables.Release(handle);
    }
}
