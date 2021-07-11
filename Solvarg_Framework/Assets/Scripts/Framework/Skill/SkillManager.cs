using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{

    #region 参数
    //特效路径-ID映射
    SkillEffectConfig effectConfig;
    private string effectConfigPath = "Assets/AssetPackage/Config/SkillEffectConfig.asset";

    

    #endregion


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
