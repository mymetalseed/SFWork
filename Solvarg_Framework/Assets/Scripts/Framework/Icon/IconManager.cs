using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IconManager : Singleton<IconManager>
{
    Dictionary<string, IconInfo> iconDict;

    /// <summary>
    /// 从配置表中获取Icon的Texture
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Texture2D> GetIconById(string id)
    {
        IconInfo info;
        if (iconDict.TryGetValue(id,out info))
        {
            string path = info.Path;

            Texture2D icon = await singletonManager.LoadAsset<Texture2D>(path);
            return icon;
        }
        return null;
    }

    /// <summary>
    /// 初始化Icon
    /// </summary>
    /// <param name="iconInfos"></param>
    public void InitIconInfo(List<IconInfo> iconInfos)
    {
        foreach (IconInfo icon in iconInfos)
        {
            iconDict.Add(icon.ID,icon);
        }
    }


    #region Unity Callback
    public override void Awake()
    {
        base.Awake();
        iconDict = new Dictionary<string, IconInfo>();
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
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
    }
    #endregion
}
