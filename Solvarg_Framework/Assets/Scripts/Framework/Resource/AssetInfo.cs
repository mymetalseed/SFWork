using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetInfo
{
    public Type AssetType { get; set; }
    public string Path { get; set; }
    private UnityEngine.Object _object;
    public int RefCount { get; set; }
    /// <summary>
    /// 是否已经加载成功
    /// </summary>
    public bool IsLoaded
    {
        get
        {
            return _object != null;
        }
    }

    public UnityEngine.Object AssetObject
    {
        get
        {
            if(_object==null)
                _ResourcesLoad();
            return _object;
        }
    }

    public IEnumerator GetCorotinueObject(Action<UnityEngine.Object> _loaded)
    {
        while (true)
        {
            yield return null;
            if (_object == null)
            {            
                _ResourcesLoad();
                yield return null;
            }
            else
            {
                if (_loaded != null)
                    _loaded(_object);
            }
            yield break;
        }
    }

    private void _ResourcesLoad()
    {
        try
        {
            _object = Resources.Load(Path);
            if (_object == null)
            {
                Debuger.LogError("Resources Load Failure! Path: " + Path);
            }
        }
        catch (Exception e)
        {
            Debuger.LogError(e.ToString());
        }
    }
    public IEnumerator GetAsyncObject(Action<UnityEngine.Object> _loaded,Action<float> _progress)
    {
        if (null != _object)
        {
            _loaded(_object);
            yield break;
        }

        //未加载
        ResourceRequest _resRequest = Resources.LoadAsync(Path);
        while (_resRequest.progress < 0.9f)
        {
            if (_progress != null)
            {
                _progress(_resRequest.progress);
                yield return null;
            }
        }

        //0.9-1.0阶段
        while (!_resRequest.isDone)
        {
            if (_progress!=null)
            {
                _progress(_resRequest.progress);
            }
            yield return null;
        }
        ///未判空
        _object = _resRequest.asset;
        if (_loaded != null)
            _loaded(_object);

        yield return _resRequest;
    }
    public IEnumerator GetAsyncObject(Action<UnityEngine.Object> _loaded)
    {
        return GetAsyncObject(_loaded, null);
    }
}
