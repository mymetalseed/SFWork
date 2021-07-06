using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 获取Texture通过id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Texture2D> GetIconById(string id)
    {
        return await iconManager.GetIconById(id);
    }

    public void InitIconInfo(List<IconInfo> icons)
    {
        iconManager.InitIconInfo(icons);
    }
}
