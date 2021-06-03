using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TestAddressble : MonoBehaviour
{
    public AssetReference baseCube;
    AsyncOperationHandle loadHandle;
    public GameObject _instance;
    public void SpawnThing()
    {
        // 使用 Addressable Name 实例化(区分大小写)
        Addressables.InstantiateAsync("Assets/AssetPackage/Test/Cube.prefab");
        // 使用 AssetReference 实例化
        Addressables.InstantiateAsync(baseCube);
        // 使用 RuntimeKey 实例化
        Addressables.InstantiateAsync(baseCube.RuntimeKey);
        // 使用 AssetReference实例方法 实例化
        baseCube.InstantiateAsync();
    }

    // Start is called before the first frame update
    async void Start()
    {
        GameObject ins = await SingletonManager.Instance.LoadAsset<GameObject>("Assets/AssetPackage/Test/Cube.prefab");
        _instance = ins;



        Debuger.Log("Instantiated finished");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(_instance);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SingletonManager.Instance.InstantiateAsync("Assets/AssetPackage/Test/Cube.prefab", obj => {

                
            });
        }
    }

    private void OnInstantiatedCompleted(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log($"Instantiate {obj.Result.name} completed.");
        _instance = obj.Result;
    }

    private void OnLoadedCompleted(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log($"Load {obj.Result.name} from async operation.");
        _instance = Instantiate(obj.Result);
    }
}
