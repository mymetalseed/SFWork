using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class Tools
{
    /// <summary>
    /// 可空类型相关的实用函数。
    /// </summary>
    public static class Nullable
    {
        /// <summary>
        /// 获取对象是否是可空类型。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="t">对象。</param>
        /// <returns>对象是否是可空类型。</returns>
        public static bool IsNullable<T>(T t) { return false; }

        /// <summary>
        /// 获取对象是否是可空类型。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="t">对象。</param>
        /// <returns>对象是否是可空类型。</returns>
        public static bool IsNullable<T>(T? t) where T : struct { return true; }
    }

    public static class Path
    {
        /// <summary>
        /// 获取规范的路径。
        /// </summary>
        /// <param name="path">要规范的路径。</param>
        /// <returns>规范的路径。</returns>
        public static string GetRegularPath(string path)
        {
            if (path == null)
            {
                return null;
            }

            return path.Replace('\\', '/');
        }

        /// <summary>
        /// 获取远程格式的路径（带有file:// 或 http:// 前缀）。
        /// </summary>
        /// <param name="path">原始路径。</param>
        /// <returns>远程格式路径。</returns>
        public static string GetRemotePath(string path)
        {
            string regularPath = GetRegularPath(path);
            if (regularPath == null)
            {
                return null;
            }

            return regularPath.Contains("://") ? regularPath : ("file:///" + regularPath).Replace("file:////", "file:///");
        }

        /// <summary>
        /// 移除空文件夹。
        /// </summary>
        /// <param name="directoryName">要处理的文件夹名称。</param>
        /// <returns>是否移除空文件夹成功。</returns>
        public static bool RemoveEmptyDirectory(string directoryName)
        {
            if (string.IsNullOrEmpty(directoryName))
            {
                throw new Exception("Directory name is invalid.");
            }

            try
            {
                if (!Directory.Exists(directoryName))
                {
                    return false;
                }

                // 不使用 SearchOption.AllDirectories，以便于在可能产生异常的环境下删除尽可能多的目录
                string[] subDirectoryNames = Directory.GetDirectories(directoryName, "*");
                int subDirectoryCount = subDirectoryNames.Length;
                foreach (string subDirectoryName in subDirectoryNames)
                {
                    if (RemoveEmptyDirectory(subDirectoryName))
                    {
                        subDirectoryCount--;
                    }
                }

                if (subDirectoryCount > 0)
                {
                    return false;
                }

                if (Directory.GetFiles(directoryName, "*").Length > 0)
                {
                    return false;
                }

                Directory.Delete(directoryName);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 随机相关的实用函数。
    /// </summary>
    public static class Random
    {
        private static System.Random s_Random = new System.Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// 设置随机数种子。
        /// </summary>
        /// <param name="seed">随机数种子。</param>
        public static void SetSeed(int seed)
        {
            s_Random = new System.Random(seed);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Int32.MaxValue 的 32 位带符号整数。</returns>
        public static int GetRandom()
        {
            return s_Random.Next();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上界（随机数不能取该上界值）。maxValue 必须大于等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 32 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        public static int GetRandom(int maxValue)
        {
            return s_Random.Next(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 32 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        public static int GetRandom(int minValue, int maxValue)
        {
            return s_Random.Next(minValue, maxValue);
        }

        /// <summary>
        /// 返回一个介于 0.0 和 1.0 之间的随机数。
        /// </summary>
        /// <returns>大于等于 0.0 并且小于 1.0 的双精度浮点数。</returns>
        public static double GetRandomDouble()
        {
            return s_Random.NextDouble();
        }

        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        public static void GetRandomBytes(byte[] buffer)
        {
            s_Random.NextBytes(buffer);
        }
    }

    /// <summary>
    /// 字符相关的实用函数。
    /// </summary>
    public static class Text
    {
        [ThreadStatic]
        private static StringBuilder s_CachedStringBuilder = null;

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0)
        {
            if (format == null)
            {
                throw new Exception("Format is invalid.");
            }

            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <param name="arg1">字符串参数 1。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0, object arg1)
        {
            if (format == null)
            {
                throw new Exception("Format is invalid.");
            }

            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0, arg1);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <param name="arg1">字符串参数 1。</param>
        /// <param name="arg2">字符串参数 2。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0, object arg1, object arg2)
        {
            if (format == null)
            {
                throw new Exception("Format is invalid.");
            }

            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0, arg1, arg2);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="args">字符串参数。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, params object[] args)
        {
            if (format == null)
            {
                throw new Exception("Format is invalid.");
            }

            if (args == null)
            {
                throw new Exception("Args is invalid.");
            }

            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, args);
            return s_CachedStringBuilder.ToString();
        }

        private static void CheckCachedStringBuilder()
        {
            if (s_CachedStringBuilder == null)
            {
                s_CachedStringBuilder = new StringBuilder(1024);
            }
        }
    }

    public static class Memory
    {
        public static void ClearMemory()
        {
            GC.Collect();
            Resources.UnloadUnusedAssets();
        }
    }

    public static class PlayerPrefsTools
    {
        public static bool HasKey(string keyName)
        {
            return PlayerPrefs.HasKey(keyName);
        }
        public static int GetInt(string keyName)
        {
            return PlayerPrefs.GetInt(keyName);
        }
        public static void SetInt(string keyName,int value)
        {
            PlayerPrefs.SetInt(keyName,value);
        }
        public static float GetFloat(string keyName)
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        public static void SetFloat(string keyName, float value)
        {
            PlayerPrefs.SetFloat(keyName, value);
        }
        public static string GetString(string keyName)
        {
            return PlayerPrefs.GetString(keyName);
        }
        public static void SetString(string keyName, string value)
        {
            PlayerPrefs.SetString(keyName, value);
        }
        public static void DeleteAllKey()
        {
            PlayerPrefs.DeleteAll();
        }
        public static void DeleteKey(string keyName)
        {
            PlayerPrefs.DeleteKey(keyName);
        }
    }

    /// <summary>
    /// 物体工具集
    /// </summary>
    public static class GameObjectTools { 
        /// <summary>
        /// 查找子物体
        /// </summary>
        /// <param name="goParent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static Transform FindTheChild(GameObject goParent,string childName)
        {
            Transform searchTrans = goParent.transform.Find(childName);
            if (searchTrans == null)
            {
                foreach(Transform trans in goParent.transform)
                {
                    searchTrans = FindTheChild(trans.gameObject, childName);
                    if (searchTrans != null)
                        break;
                }
            }
            return searchTrans;
        }
        
        /// <summary>
        /// 获取子物体脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="goParent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static T GetTheChildComponnet<T>(GameObject goParent,string childName) where T: Component
        {
            Transform searchTrans = FindTheChild(goParent, childName);
            if (searchTrans != null)
            {
                return searchTrans.gameObject.GetComponent<T>();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 给子物体添加脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="goParent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static T AddTheChildComponent<T>(GameObject goParent,string childName) where T : Component
        {
            Transform searchTrans = FindTheChild(goParent, childName);
            if (searchTrans != null)
            {
                T[] theComponnetsArr = searchTrans.GetComponents<T>();
                for(int i = 0; i < theComponnetsArr.Length; ++i)
                {
                    if (theComponnetsArr[i]!=null)
                    {
                        GameObject.Destroy(theComponnetsArr[i]);
                    }
                }
                return searchTrans.gameObject.AddComponent<T>();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 添加子物体
        /// </summary>
        public static void AddChildToParent(Transform parentTrans,Transform childTrans)
        {
            childTrans.parent = parentTrans;
            childTrans.localPosition = Vector3.zero;
            childTrans.localScale = Vector3.one;
            childTrans.localEulerAngles = Vector3.zero;
            SetLayer(parentTrans.gameObject.layer, childTrans);
        }
        /// <summary>
        /// 递归设置layer
        /// </summary>
        /// <param name="parentLayer"></param>
        /// <param name="childTrans"></param>
        public static void SetLayer(int parentLayer,Transform childTrans)
        {
            childTrans.gameObject.layer = parentLayer;
            for(int i = 0; i < childTrans.childCount; ++i)
            {
                Transform child = childTrans.GetChild(i);
                child.gameObject.layer = parentLayer;
                SetLayer(parentLayer, child);
            }
        }

    }
}
