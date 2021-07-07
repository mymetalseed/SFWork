using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Tools;

public class WeaponManager : Singleton<WeaponManager>
{
    private string weaponConfigPath = "Assets/AssetPackage/Config/WeaponConfig.asset";
    private WeaponConfig weaponConfig;
    private DoubleMap<int, string> weapon_item_Map;
    private Dictionary<int, WeaponInfo> weaponMap;

    #region Function
    /// <summary>
    /// 通过武器Id获取武器实体
    /// </summary>
    /// <param name="wid"></param>
    /// <returns></returns>
    public async Task<Weapon> GetWeaponByWid(int wid)
    {
        string itemId = weapon_item_Map.GetValueByKey(wid);
        Weapon nw = null;
        if (itemId != null)
        {
            nw = await singletonManager.GetItem<Weapon>(itemId);
            nw.SetWeaponInfo(weaponMap[wid]);
        }
        return nw;
    }

    /// <summary>
    /// 将武器挂载到角色身上
    /// </summary>
    /// <param name="role"></param>
    /// <param name="weapon"></param>
    public void LinkToRole(BaseCreature role,Weapon weapon)
    {
        GameObject roleObj = role.gameObject;
        Transform targetTrans = GameObjectTools.FindTheChild(roleObj,weapon.WeaponInfo.targetSpineNode);
        if (targetTrans != null)
        {
            WeaponController weaponController = role[ControllerType.Weapon] as WeaponController;
            if (weaponController != null)
            {
                //先让旧的持有者丢弃武器
                if (weaponController.currentWeapon != null)
                {
                    Debug.LogError("开始尝试释放武器");
                    weaponController?.TryReleaseWeapon();
                }

                //如果是旧的武器直接过来
                if (weapon.owner != null)
                {
                    Debug.LogError("开始尝试释放武器");
                    WeaponController oldWeaponController = weapon.owner[ControllerType.Weapon] as WeaponController;
                    oldWeaponController?.TryReleaseWeapon();
                }

                //添加武器引用关系
                weaponController.currentWeapon = weapon;
                weapon.owner = role;

                Transform weaponTrans = weapon.ItemModel.transform;
                weaponTrans.parent = targetTrans;
                weaponTrans.localPosition = weapon.WeaponInfo.weaponPos;
                weaponTrans.localRotation = Quaternion.Euler(weapon.WeaponInfo.weaponRot);
                weaponTrans.localScale = weapon.WeaponInfo.weaponSacale;
            }
        }
    }

    /// <summary>
    /// 通过武器id生成武器并挂载到角色身上
    /// </summary>
    /// <param name="role"></param>
    /// <param name="wid"></param>
    /// <returns></returns>
    public async Task<Weapon> LinkWeaponToRole(BaseCreature role,int wid)
    {
        Weapon weapon = await GetWeaponByWid(wid);
        if (weapon != null)
        {
            LinkToRole(role,weapon);
        }
        return weapon;
    }

    #endregion

    #region Unity Callback
    public async override void Awake()
    {
        base.Awake();
        weapon_item_Map = new DoubleMap<int, string>();
        weaponMap = new Dictionary<int, WeaponInfo>();

        //初始化Weapon信息
        weaponConfig = await singletonManager.LoadAsset<WeaponConfig>(weaponConfigPath);

        foreach(WeaponInfo wi in weaponConfig.weapons)
        {
            weapon_item_Map.Add(wi.weaponId,wi.itemId);
            weaponMap.Add(wi.weaponId,wi);
        }
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
