using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public partial class SingletonManager
{
    /// <summary>
    /// 基于动画系统直接播放动画
    /// </summary>
    /// <param name="eId">特效资源Id</param>
    /// <param name="pos">特效资源位置</param>
    /// <param name="rot">特效资源旋转</param>
    /// <param name="scale">特效资源缩放</param>
    /// <param name="isWorld">是否是世界坐标</param>
    /// <param name="role">给哪个角色实体用</param>
    /// <param name="target">目标挂点名字</param>
    public void DoSkillEffect(
        SkillEffectDisplayInfo skill,BaseCreature role = null
        )
    {
        skillManager.DoSkillEffect(skill, role);
    }
}
