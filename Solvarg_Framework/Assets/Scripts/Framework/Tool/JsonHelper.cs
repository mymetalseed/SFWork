using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class JsonHelper 
{
    /// <summary>
    /// 反序列化-只接受json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    public static T Deserialize<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }

    /// <summary>
    /// 从路径进行反序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public async static Task<T> DeserializeFromPath<T>(string path)
    {
        string jsonText = (await SingletonManager.Instance.LoadAsset<TextAsset>(path)).text;
        return Deserialize<T>(jsonText);
    }





}
