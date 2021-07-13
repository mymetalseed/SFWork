using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFAction_BuffTakeDamage : SFAction_BaseAction
{
    [HideInInspector]
    public SkillStateID skillID;

    /*
     * 掉血
     * 
     * 播放受伤动画
     */ 
    public override void TrigAction()
    {
        BaseCreature attacker = owner.GetComponent<BaseCreature>();
        BaseCreature defencer = target.GetComponent<BaseCreature>();

        //1 : hp
        //2 : attack
        int hp = defencer.CurrentHp;
        int attack = attacker.GetCurrentMaxAttack; 

        if(attacker.info.playerSide == PlayerSide.Player)
        {
            //怪物攻击角色
        }

        //TODO: 执行血量减少等
        if (hp <= 0)
        {

        }
        else{

        }
    }
}
