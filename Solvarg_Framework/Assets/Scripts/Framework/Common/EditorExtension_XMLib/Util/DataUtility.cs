/*
 * 作者：Peter Xiang
 * 联系方式：565067150@qq.com
 * 文档: https://github.com/PxGame
 * 创建时间: 2019/10/14 10:30:51
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace XMLib
{
    /// <summary>
    /// DataUtility
    /// </summary>
    public static class DataUtility
    {
        #region json

        public static JsonSerializerSettings jsonSetting;

        static DataUtility()
        {
            jsonSetting = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
            };
        }

        public static string ToJson<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj, jsonSetting);
            return json;
        }

        public static T FromJson<T>(string json)
        {
            T obj = JsonConvert.DeserializeObject<T>(json, jsonSetting);
            return obj;
        }

        public static object FromJson(string json)
        {
            object obj = JsonConvert.DeserializeObject(json, jsonSetting);
            return obj;
        }

        public static byte[] ToJsonBytes<T>(T obj)
        {
            string json = ToJson(obj);
            return Encoding.UTF8.GetBytes(json);
        }

        public static T FromJsonBytes<T>(byte[] jsonBytes)
        {
            string json = Encoding.UTF8.GetString(jsonBytes);
            return FromJson<T>(json);
        }

        public static string ToJson(object obj, Type type)
        {
            string json = JsonConvert.SerializeObject(obj, type, jsonSetting);
            return json;
        }

        public static object FromJson(string json, Type type)
        {
            object obj = JsonConvert.DeserializeObject(json, type, jsonSetting);
            return obj;
        }

        #endregion json

    }
}