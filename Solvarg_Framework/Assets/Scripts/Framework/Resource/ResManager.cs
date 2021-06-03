using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResManager : Singleton<ResManager>
{
    private Dictionary<string, AssetInfo> dicAssetInfo = null;
    public override void Awake()
    {
        Debuger.Log("初始化Resources模块");

        dicAssetInfo = new Dictionary<string, AssetInfo>();
    }

    #region Load Resources & Instantiate Object
    public UnityEngine.Object LoadInstance(string _path)
    {
        UnityEngine.Object _obj = Load(_path);
        return Instantiate(_obj);
    }
    public void LoadCorotineInstance(string _path,Action<UnityEngine.Object> _loaded)
    {
        LoadCorotinue(_path, (_obj) =>
        {
            Instantiate(_obj, _loaded);
        });
    }
    public void LoadAsyncInstance(string _path, Action<UnityEngine.Object> _loaded)
    {
        LoadAsync(_path, (_obj) =>
        {
            Instantiate(_obj, _loaded);
        });
    }
    public void LoadAsyncInstance(string _path, Action<UnityEngine.Object> _loaded,Action<float> _progress)
    {
        LoadAsync(_path, (_obj) =>
        {
            Instantiate(_obj, _loaded);
        },_progress);
    }
    #endregion

    #region Load Resources
    public UnityEngine.Object Load(string _path)
    {
        AssetInfo _assetInfo = GetAssetInfo(_path);
        if (_assetInfo != null)
        {
            return _assetInfo.AssetObject;
        }
        return null;
    }
    #endregion

    #region Load Coroutine Resources
    public void LoadCorotinue(string _path, Action<UnityEngine.Object> _loaded)
    {
        AssetInfo _assetInfo = GetAssetInfo(_path, _loaded);
        if (_assetInfo != null)
        {
            singletonManager.StartCoroutine(_assetInfo.GetCorotinueObject(_loaded));
        }
    }
    #endregion

    #region Load Async Resources
    public void LoadAsync(string _path, Action<UnityEngine.Object> _loaded)
    {
        LoadAsync(_path, _loaded, null);
    }
    public void LoadAsync(string _path, Action<UnityEngine.Object> _loaded, Action<float> _progress)
    {
        AssetInfo _assetInfo = GetAssetInfo(_path, _loaded);
        if (_assetInfo != null)
        {
            singletonManager.StartCoroutine(_assetInfo.GetAsyncObject(_loaded, _progress));
        }
    }
    #endregion

    #region Get AssetInfo & Instantiate Object
    private UnityEngine.Object Instantiate(UnityEngine.Object _obj) {
        return Instantiate(_obj, null);
    }

    private UnityEngine.Object Instantiate(UnityEngine.Object _obj,Action<UnityEngine.Object> _loaded)
    {
        UnityEngine.Object _retObj = null;
        if (_obj != null)
        {
            _retObj = MonoBehaviour.Instantiate(_obj);
            if (_retObj!= null)
            {
                if (_loaded != null)
                {
                    _loaded(_retObj);
                    return null;
                }
                return _retObj;
            }
            else
            {
                Debuger.LogError("Error: null Instantiate _retObj.");
            }
        }
        else
        {
            Debuger.LogError("Error: null Resources Load return _obj;");
        }
        return null;
    }

    private AssetInfo GetAssetInfo(string _path,Action<UnityEngine.Object> _loaded)
    {
        if (string.IsNullOrEmpty(_path))
        {
            Debuger.LogError("Error: null _path name.");
            if (null != _loaded)
            {
                _loaded(null);
            }
        }
        // 加载资源....
        AssetInfo _assetInfo = null;
        if (!dicAssetInfo.TryGetValue(_path, out _assetInfo))
        {
            _assetInfo = new AssetInfo();
            _assetInfo.Path = _path;
            dicAssetInfo.Add(_path, _assetInfo);
        }
        _assetInfo.RefCount++;
        return _assetInfo;
    }

    private AssetInfo GetAssetInfo(string _path)
    {
        return GetAssetInfo(_path, null);
    }
    #endregion
}
