using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;

public class LuaManager : Singleton<LuaManager>
{
    public string luaMainFunc = "main";

    private bool isLuaStarted;
    public string luaPath;

    LuaEnv luaenv = null;
    protected List<string> searchPaths = new List<string>();

    public void Init()
    {
        luaenv = new LuaEnv();

        if (string.IsNullOrEmpty(luaPath))
        {
            luaPath = Path.Combine(Application.dataPath, "../Lua");
        }

        AddSearchPath(luaPath);

        luaenv.AddLoader(Loader);

    }

    private byte[] Loader(ref string filepath)
    {
        filepath = filepath.Replace(".", "/");
        byte[] bytes = null;
        var newfilePath = FindFile(filepath);
        Debuger.Log("加载Lua: " + newfilePath);

        if (newfilePath != null)
        {
            filepath = Path.GetFullPath(newfilePath);
            bytes = System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(newfilePath));
        }

        if (bytes != null) return bytes;

        Debuger.Log("Lua文件为空: " + newfilePath);
        return null;

    }

    public string FindFile(string fileName)
    {
        if (fileName == string.Empty)
        {
            return string.Empty;
        }

        if (Path.IsPathRooted(fileName))
        {
            if (!fileName.EndsWith(".lua"))
            {
                fileName += ".lua";
            }

            return fileName;
        }

        if (fileName.EndsWith(".lua"))
        {
            fileName = fileName.Substring(0, fileName.Length - 4);
        }

        string fullPath = null;

        for (int i = 0; i < searchPaths.Count; i++)
        {
            fullPath = searchPaths[i].Replace("?", fileName);
            if (File.Exists(fullPath))
            {
                return fullPath;
            }
            else
            {
                Debug.Log("不存在fullPath " + fullPath);
            }
        }
        return null;
    }

    string ToPackagePath(string path)
    {
        StringBuilder sb = new StringBuilder("");
        sb.Append(path);
        sb.Replace('\\', '/');

        if (sb.Length > 0 && sb[sb.Length - 1] != '/')
        {
            sb.Append('/');
        }

        sb.Append("?.lua");
        return sb.ToString();
    }

    public bool RemoveSearchPath(string path)
    {
        int index = searchPaths.IndexOf(path);

        if (index >= 0)
        {
            searchPaths.RemoveAt(index);
            return true;
        }

        return false;
    }

    public bool AddSearchPath(string path, bool front = false)
    {
        path = ToPackagePath(path);
        int index = searchPaths.IndexOf(path);

        if (index >= 0)
        {
            return false;
        }

        if (front)
        {
            searchPaths.Insert(0, path);
        }
        else
        {
            searchPaths.Add(path);
        }

        return true;
    }





    #region Unity callback

    public override void Awake()
    {
        base.Awake();
        Init();
        luaenv.DoString($"LUA_XLua = true \n require '{luaMainFunc}'");
        isLuaStarted = true;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnGUI()
    {
        base.OnGUI();
    }

    public override void OnRelease()
    {
        if (luaenv != null)
        {
            luaenv.Dispose();
        }
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
        if (luaenv != null)
        {
            luaenv.Tick();
        }
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }
    #endregion
}
