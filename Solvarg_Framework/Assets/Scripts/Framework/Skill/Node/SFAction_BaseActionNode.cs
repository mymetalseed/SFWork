using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SolvargAction
{
    public abstract class SFAction_BaseActionNode : SFAction_BaseNode
    {
        private SFAction_StateNode baseState;
        public SFAction_StateNode BaseState {
            get
            {
                if(baseState == null)
                {
                    NodePort port = null;
                    port = GetInputPort("input");
                    if(port != null)
                    {
                        baseState = port.GetConnection(0).node as SFAction_StateNode;
                    }
                }
                return baseState;
            }    
        }

        public override SF_NodeType GetNodeType => SF_NodeType.Behaviour;

        #region 运行时
        [HideInInspector]
        public object config;

        /// <summary>
        /// doAction,返回是否当前状态被强行终止
        /// 比如中途退出当前状态
        /// 比如条件检测满足当前状态
        /// </summary>
        /// <returns></returns>
        public abstract bool DoAction();

        public override void Execute()
        {
        }
        #endregion
    }
}