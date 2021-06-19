using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// 包括所有的可配置项以及
/// 运行时的配置项
/// </summary>
public class SettingManager : Singleton<SettingManager>,ISetting
{
    private readonly SortedDictionary<string, string> m_Settings = new SortedDictionary<string, string>(StringComparer.Ordinal);

    public int Count {
        get
        {
            return m_Settings.Count;
        }
    }
    /// <summary>
    /// 获取所有游戏配置项的名称。
    /// </summary>
    /// <returns>所有游戏配置项的名称。</returns>
    public string[] GetAllSettingNames()
    {
        int index = 0;
        string[] allSettingName = new string[m_Settings.Count];
        foreach(KeyValuePair<string,string> setting in m_Settings)
        {
            allSettingName[index++] = setting.Key;
        }

        return allSettingName;
    }

    /// <summary>
    /// 获取所有游戏配置项的名称。
    /// </summary>
    /// <param name="results">所有游戏配置项的名称。</param>
    public void GetAllSettingNames(List<string> results)
    {
        if (results == null)
        {
            Debuger.LogError("Result is invalid");
        }
        results.Clear();
        foreach(KeyValuePair<string,string> setting in m_Settings)
        {
            results.Add(setting.Key);
        }
    }

    /// <summary>
    /// 从指定游戏配置项中读取布尔值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的布尔值。</returns>
    public bool GetBool(string settingName)
    {
        string value = null;
        if(!m_Settings.TryGetValue(settingName,out value))
        {
            Debuger.LogWarning("Setting '"+ settingName + "' is not exist.");
            return false;
        }

        return int.Parse(value) != 0;
    }

    /// <summary>
    /// 从指定游戏配置项中读取布尔值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultValue">当指定的游戏配置项不存在时，返回此默认值。</param>
    /// <returns>读取的布尔值。</returns>
    public bool GetBool(string settingName, bool defaultValue)
    {
        string value = null;
        if (!m_Settings.TryGetValue(settingName, out value))
        {
            return defaultValue;
        }

        return int.Parse(value) != 0;
    }

    /// <summary>
    /// 从指定游戏配置项中读取浮点数值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的浮点数值。</returns>
    public float GetFloat(string settingName)
    {
        string value = null;
        if (!m_Settings.TryGetValue(settingName, out value))
        {
            Debug.LogWarning("Setting '" + settingName + "' is not exist.");
            return 0f;
        }

        return float.Parse(value);
    }

    /// <summary>
    /// 从指定游戏配置项中读取浮点数值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultValue">当指定的游戏配置项不存在时，返回此默认值。</param>
    /// <returns>读取的浮点数值。</returns>
    public float GetFloat(string settingName, float defaultValue)
    {
        string value = null;
        if (!m_Settings.TryGetValue(settingName, out value))
        {
            return defaultValue;
        }

        return float.Parse(value);
    }

    /// <summary>
    /// 从指定游戏配置项中读取整数值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的整数值。</returns>
    public int GetInt(string settingName)
    {
        string value = null;
        if (!m_Settings.TryGetValue(settingName, out value))
        {
            Debuger.LogWarning("Setting '"+ settingName + "' is not exist.");
            return 0;
        }

        return int.Parse(value);
    }

    /// <summary>
    /// 从指定游戏配置项中读取整数值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultValue">当指定的游戏配置项不存在时，返回此默认值。</param>
    /// <returns>读取的整数值。</returns>
    public int GetInt(string settingName, int defaultValue)
    {
        string value = null;
        if (!m_Settings.TryGetValue(settingName, out value))
        {
            return defaultValue;
        }

        return int.Parse(value);
    }


    public T GetObject<T>(string settingName)
    {
        return JsonHelper.Deserialize<T>(GetString(settingName));
    }

    public object GetObject(Type objectType, string settingName)
    {
        return JsonHelper.Deserialize(objectType, GetString(settingName));
    }

    public T GetObject<T>(string settingName, T defaultObj)
    {
        string json = GetString(settingName, null);
        if (json == null)
        {
            return defaultObj;
        }

        return JsonHelper.Deserialize<T>(json);
    }

    public object GetObject(Type objectType, string settingName, object defaultObj)
    {
        string json = GetString(settingName, null);
        if (json == null)
        {
            return defaultObj;
        }

        return JsonHelper.Deserialize(objectType, json);
    }

    /// <summary>
    /// 从指定游戏配置项中读取字符串值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的字符串值。</returns>
    public string GetString(string settingName)
    {
        string value = null;
        if (!m_Settings.TryGetValue(settingName, out value))
        {
            Debuger.LogWarning("Setting '"+ settingName + "' is not exist.");
            return null;
        }

        return value;
    }

    /// <summary>
    /// 从指定游戏配置项中读取字符串值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultValue">当指定的游戏配置项不存在时，返回此默认值。</param>
    /// <returns>读取的字符串值。</returns>
    public string GetString(string settingName, string defaultValue)
    {
        string value = null;
        if (!m_Settings.TryGetValue(settingName, out value))
        {
            return defaultValue;
        }

        return value;
    }

    /// <summary>
    /// 检查是否存在指定游戏配置项。
    /// </summary>
    /// <param name="settingName">要检查游戏配置项的名称。</param>
    /// <returns>指定的游戏配置项是否存在。</returns>
    public bool HasSetting(string settingName)
    {
        return m_Settings.ContainsKey(settingName);
    }

    /// <summary>
    /// 加载游戏配置
    /// </summary>
    /// <returns></returns>
    public bool Load()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 清空所有游戏配置项。
    /// </summary>
    public void RemoveAllSettings()
    {
        m_Settings.Clear();
    }

    /// <summary>
    /// 移除指定游戏配置项。
    /// </summary>
    /// <param name="settingName">要移除游戏配置项的名称。</param>
    /// <returns>是否移除指定游戏配置项成功。</returns>
    public bool RemoveSetting(string settingName)
    {
        return m_Settings.Remove(settingName);
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 向指定游戏配置项写入布尔值。
    /// </summary>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="value">要写入的布尔值。</param>
    public void SetBool(string settingName, bool value)
    {
        m_Settings[settingName] = value ? "1" : "0";
    }

    /// <summary>
    /// 向指定游戏配置项写入浮点数值。
    /// </summary>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="value">要写入的浮点数值。</param>
    public void SetFloat(string settingName, float value)
    {
        m_Settings[settingName] = value.ToString();
    }

    /// <summary>
    /// 向指定游戏配置项写入整数值。
    /// </summary>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="value">要写入的整数值。</param>
    public void SetInt(string settingName, int value)
    {
        m_Settings[settingName] = value.ToString();
    }


    /// <summary>
    /// 向指定游戏配置项写入对象。
    /// 存储方式,序列化成json
    /// </summary>
    /// <typeparam name="T">要写入对象的类型。</typeparam>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="obj">要写入的对象。</param>
    public void SetObject<T>(string settingName, T obj)
    {
        SetString(settingName, JsonHelper.SerializeObjectToJson(obj));
    }

    public void SetObject(string settingName, object obj)
    {
        SetString(settingName, JsonHelper.SerializeObjectToJson(obj));
    }

    public void SetString(string settingName, string value)
    {
        m_Settings[settingName] = value;
    }


    /// <summary>
    /// 序列化当前配置数据。
    /// </summary>
    /// <param name="stream">目标流。</param>
    public void Serialize(/*配置*/)
    {
        //TODO: 存储配置
    }

    /// <summary>
    /// 反序列化数据到当前配置中。
    /// </summary>
    /// <param name="stream">指定流。</param>
    public void Deserialize(/*配置*/)
    {
        m_Settings.Clear();
        //TODO: 加载配置
    }

    public override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// 游戏配置管理器轮询。
    /// </summary>
    /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
    /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }

    /// <summary>
    /// 释放时保存
    /// </summary>
    public override void OnRelease()
    {
        base.OnRelease();
        Save();
    }

}
