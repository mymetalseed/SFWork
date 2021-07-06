using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 通过模型Id获取模型实体
    /// </summary>
    /// <param name="mid"></param>
    /// <returns></returns>
    public async Task<GameObject> GetModelById(string mid)
    {
        ModelConfig modelConfig = _instance.GetModelConfigById(mid);
        if (modelConfig == null) return null;

        GameObject model = await _instance.InstantiateAsync(modelConfig.Path);
        model.name = modelConfig.Name;
        return model;
    }
}
