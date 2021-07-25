using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SkillConfig;

namespace SolvargAction
{
    public enum ComboEventType
    {
        InputEvents,
    }

    [CreateNodeMenu("行为/触发技能")]
    public class SFAction_CastSkillActionNode : SFAction_BaseActionNode
    {
        [AllowNesting]
        [Label("是否连击")]
        public bool isCombo=false;

        [AllowNesting]
        [Label("触发连击的方式")]
        public ComboEventType comboType;

        [AllowNesting]
        [Label("连击触发按键")]
        public List<InputEvents> comboEvents;

        /// <summary>
        /// Buff和特效直接放到Skill设置中进行操作
        /// 这里只负责在动画某一个时间节点上进行技能的释放,具体释放逻辑后面再写
        /// 碰撞体偏移数据放在这里进行
        /// </summary>
        public List<SkillConfig> skillConfigs;

        private BaseCreature _owner;
        private BaseCreature owner
        {
            get
            {
                if(_owner == null)
                {
                    _owner = Graph.owner as BaseCreature;
                }
                return _owner;
            }
        }
        private int skillCount;
        private List<string> animNames;

        public override bool DoAction()
        {
            if (isCombo)
            {
                if (comboType == ComboEventType.InputEvents)
                {
                    if (isPlaying && curAnimSkillIndex<skillCount && InputData.HasEvent(comboEvents[curAnimSkillIndex]))
                    {
                        CastSkill();
                    }
                }
            }

            return false;
        }
        public override void EnterAction()
        {
            animNames = BaseState.animNames;
            skillCount = animNames.Count;
            curAnimSkillIndex = 0;
            isPlaying = false;
            isReady = true;


            CastSkill();
        }

        public override void ExitAction()
        {
        }


        #region 攻击捕捉

        bool isReady;
        bool isPlaying;
        int curAnimSkillIndex;

        public void CastSkill()
        {
            if (!isReady)
            {
                return;
            }

            if(skillCount > 1)
            {
                if(curAnimSkillIndex > skillCount)
                {
                    curAnimSkillIndex = 0;
                }
            }

            SingletonManager.Instance.StartAnimation(owner, animNames[curAnimSkillIndex], CastSkillReady, CastSkillBegin, CastSkillEnd, CastSkillEnd1);
        }

        void CastSkillReady()
        {
            if (skillCount > 1)
            {
                isReady = true;
            }
        }

        void CastSkillBegin()
        {
            isPlaying = true;
            if (skillCount > 1)
            { 
                isReady = false;
                curAnimSkillIndex++;
            }
            //加载特效
            int eIndex = skillCount > 1 ? curAnimSkillIndex - 1 : 0;
            if(skillConfigs!=null && skillConfigs.Count>= eIndex && skillConfigs[eIndex] !=null)
            {
                SkillConfig skill = skillConfigs[eIndex];
                List<SkillEffectDisplayInfo> effectInfo = skill.displayInfo;

                for(int i = 0; i < effectInfo.Count; ++i)
                {
                    SkillEffectDisplayInfo info = effectInfo[i];
                    SingletonManager.Instance.Timer_Register(info.duration, ()=> {
                        //不等待
                        SingletonManager.Instance.DoSkillEffect(info,owner);
                    }); 
                }

            }

            //加载技能等
        }
        void CastSkillEnd1()
        {

        }

        void CastSkillEnd()
        {
            if (skillCount > 1)
            {
                curAnimSkillIndex = 0;
                isReady = true;
            }

            AnimatorStateInfo state = owner.Anim.GetCurrentAnimatorStateInfo(0);
            if(state.IsName("Base Layer.GetHit"))
            {

            }
            else
            {
                isPlaying = false;
                //连击执行完毕
                BaseState.SetComboTrigger();
            }
        }

        #endregion

    }
}