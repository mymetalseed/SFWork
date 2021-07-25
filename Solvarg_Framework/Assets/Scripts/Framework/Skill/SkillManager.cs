using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Tools;

public class SkillManager : Singleton<SkillManager>
{
    #region 参数
    //特效路径-ID映射
    SkillEffectConfig effectConfig;
    private string effectConfigPath = "Assets/AssetPackage/Config/SkillEffectConfig.asset";

    #endregion

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
    public async Task DoSkillEffect(
        string eId,
        Vector3 pos, Vector3 rot, Vector3 scale,
        bool isWorld=true,BaseCreature role=null,string target="",float existTimer = 1
        )
    {
        SkillEffectInfo info = effectConfig.infoDict[eId];
        Debuger.LogError(info.effectId);
        if (isWorld)
        {
            //Assets/AssetPackage/Particles/Prefab/MagicChargeBlue.prefab
            role = role ?? singletonManager.PlayerInst;
            Transform targetTrans = null;
            if (target != null && target != "")
            {
                targetTrans = GameObjectTools.FindTheChild(role.gameObject, target);
            }
            GameObject effect = await singletonManager.InstantiateAsync(info.effectPath);
            effect.SetActive(false);
            effect.transform.parent = targetTrans;
            effect.transform.localPosition = pos;
            effect.transform.localRotation = Quaternion.Euler(rot);
            effect.transform.localScale = scale;
            effect.transform.parent = null;
            effect.SetActive(true);
            singletonManager.Timer_Register(existTimer, () =>
            {
                GameObject.Destroy(effect);
            });
        }
        else
        {
            role = role ?? singletonManager.PlayerInst;
            Transform targetTrans = GameObjectTools.FindTheChild(role.gameObject, target);
            if (targetTrans != null)
            {
                GameObject effect = await singletonManager.InstantiateAsync(info.effectPath, targetTrans);
                effect.SetActive(false);
                effect.transform.localPosition = pos;
                effect.transform.localRotation = Quaternion.Euler(rot);
                effect.transform.localScale = scale;
                effect.SetActive(true);
                singletonManager.Timer_Register(existTimer, () =>
                {
                    GameObject.Destroy(effect);
                });
            }
        }
    }

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
    public async Task DoSkillEffect(
        SkillEffectDisplayInfo skill, BaseCreature role = null
        )
    {
        SkillEffectInfo info = effectConfig.infoDict[skill.effectId];
        Debuger.LogError(info.effectId);

        await DoSkillEffect(skill.effectId,skill.pos,skill.rot,skill.scale,!skill.isLocal,role,skill.targetName,skill.existTimer);
    }

    #region Unity Callback
    public async override void Awake()
    {
        base.Awake();
        effectConfig = await singletonManager.LoadAsset<SkillEffectConfig>(effectConfigPath);
        effectConfig.DoInit();
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
